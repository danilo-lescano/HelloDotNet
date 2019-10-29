using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaCertoForms.Models;
using TaCertoForms.Attributes;
using TaCertoForms.Contexts;
using TaCertoForms.Controllers.Base;

namespace TaCertoForms.Controllers{
    [SomenteLogado]
    public class InstituicaoController : ControladoraBase {
        
        public ActionResult Index() {            
            return View(CollectionMatriz.InstituicaoList());
        }
        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ViewModelInstituicao viewModel) {
            //Todo validar se algum field veio null
            Endereco principal = viewModel.enderecoPrincipal;
            CollectionMatriz.CreateEndereco(principal);
            //Capturando o id do endereço principal que foi inserido no banco
            int IdEnderecoPrincipal = principal.IdEndereco;
            int IdEnderecoCobranca;
            Endereco cobranca = viewModel.enderecoCobranca;
            if (cobranca != null) {
                CollectionMatriz.CreateEndereco(cobranca);
                //Capturando o id do endereço de cobrança que foi inserido no banco
                IdEnderecoCobranca = cobranca.IdEndereco;
            }
            else
                IdEnderecoCobranca = IdEnderecoPrincipal;
            Instituicao instituicao = viewModel.instituicao;
            instituicao.IdEnderecoCobranca = IdEnderecoCobranca;
            instituicao.IdEnderecoPrincipal = IdEnderecoPrincipal;
            CollectionMatriz.CreateInstituicao(instituicao);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id) {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ViewModelInstituicao vmInstituicao = new ViewModelInstituicao();
            Instituicao instituicao = CollectionMatriz.FindInstituicao(id);
            if (instituicao == null)
                return HttpNotFound();
            vmInstituicao.instituicao = instituicao;

            Endereco enderecoPrincipal = CollectionMatriz.FindEndereco(instituicao.IdEnderecoPrincipal);
            Endereco enderecoCobranca = null;
            if (instituicao.IdEnderecoPrincipal != instituicao.IdEnderecoCobranca)
                enderecoCobranca = CollectionMatriz.FindEndereco(instituicao.IdEnderecoCobranca);
            ViewBag.enderecoCobranca = enderecoCobranca;
            ViewBag.enderecoPrincipal = enderecoPrincipal;

            vmInstituicao.Midia = db.Midia.Where(x => x.IdOrigem == id && x.Tabela == "Instituicao").FirstOrDefault<Midia>();
                        
            return View(vmInstituicao);
        }

        [HttpPost]
        public ActionResult Edit(ViewModelInstituicao viewModel) {
            Instituicao instituicao = viewModel.instituicao;
            if(CollectionMatriz.FindInstituicao(instituicao.IdInstituicao) == null)
                return HttpNotFound();
            //Caso o usuário já tinha cadastrado um email de cobrança diferente do principal e optou por tornar o endereço de cobrança como o mesmo endereço principal            
            if (viewModel.EqualEnderecoCobranca && viewModel.IdEnderecoCobranca != viewModel.IdEnderecoPrincipal) {
                viewModel.IdEnderecoCobranca = viewModel.IdEnderecoPrincipal;
                instituicao.IdEnderecoCobranca = viewModel.IdEnderecoPrincipal;
            }
            else if (viewModel.EqualEnderecoCobranca == false && viewModel.IdEnderecoCobranca == viewModel.IdEnderecoPrincipal) {
                Endereco cobranca = viewModel.enderecoCobranca;
                CollectionMatriz.CreateEndereco(cobranca);
                instituicao.IdEnderecoCobranca = cobranca.IdEndereco;
            }
            else if (viewModel.EqualEnderecoCobranca == false) {
                //Atualizando endereço cobranca
                Endereco cobranca = viewModel.enderecoCobranca;
                CollectionMatriz.EditEndereco(cobranca);
            }
            //Atualizando endereço principal
            Endereco principal = viewModel.enderecoPrincipal;
            CollectionMatriz.EditEndereco(principal);

            CollectionMatriz.EditInstituicao(instituicao);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id) {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Instituicao instituicao = CollectionMatriz.FindInstituicao(id);
            if (instituicao == null)
                return HttpNotFound();

            Endereco enderecoPrincipal = CollectionMatriz.FindEndereco(instituicao.IdEnderecoPrincipal);
            Endereco enderecoCobranca = null;
            if (instituicao.IdEnderecoPrincipal != instituicao.IdEnderecoCobranca)
                enderecoCobranca = CollectionMatriz.FindEndereco(instituicao.IdEnderecoCobranca);
            ViewBag.enderecoCobranca = enderecoCobranca;
            ViewBag.enderecoPrincipal = enderecoPrincipal;
            return View(instituicao);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            CollectionMatriz.DeleteInstituicao(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    }
}
