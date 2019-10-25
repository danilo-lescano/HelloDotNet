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
            return View(GetMinhasInstituicoes());
        }
        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ViewModelInstituicao viewModel) {
            //Todo validar se algum field veio null
            Endereco principal = viewModel.enderecoPrincipal;
            db.Endereco.Add(principal);
            db.SaveChanges();
            //Capturando o id do endereço principal que foi inserido no banco
            int IdEnderecoPrincipal = principal.IdEndereco;
            int IdEnderecoCobranca;
            Endereco cobranca = viewModel.enderecoCobranca;
            if (cobranca != null) {
                db.Endereco.Add(cobranca);
                db.SaveChanges();
                //Capturando o id do endereço de cobrança que foi inserido no banco
                IdEnderecoCobranca = cobranca.IdEndereco;
            }
            else
                IdEnderecoCobranca = IdEnderecoPrincipal;
            Instituicao instituicao = viewModel.instituicao;
            instituicao.IdEnderecoCobranca = IdEnderecoCobranca;
            instituicao.IdEnderecoPrincipal = IdEnderecoPrincipal;
            instituicao.IdMatriz = (int?)Session["IdMatriz"];
            db.Instituicao.Add(instituicao);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id) {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ViewModelInstituicao vmInstituicao = new ViewModelInstituicao();
            Instituicao instituicao = FindMinhaInstituicao(id);
            if (instituicao == null)
                return HttpNotFound();
            vmInstituicao.instituicao = instituicao;

            Endereco enderecoPrincipal = db.Endereco.Find(instituicao.IdEnderecoPrincipal);
            Endereco enderecoCobranca = null;
            if (instituicao.IdEnderecoPrincipal != instituicao.IdEnderecoCobranca)
                enderecoCobranca = db.Endereco.Find(instituicao.IdEnderecoCobranca);
            ViewBag.enderecoCobranca = enderecoCobranca;
            ViewBag.enderecoPrincipal = enderecoPrincipal;

            vmInstituicao.Midia = db.Midia.Where(x => x.IdOrigem == id && x.Tabela == "Instituicao").FirstOrDefault<Midia>();
                        
            return View(vmInstituicao);
        }

        [HttpPost]
        public ActionResult Edit(ViewModelInstituicao viewModel) {
            Instituicao instituicao = viewModel.instituicao;
            //Caso o usuário já tinha cadastrado um email de cobrança diferente do principal e optou por tornar o endereço de cobrança como o mesmo endereço principal            
            if (viewModel.EqualEnderecoCobranca && viewModel.IdEnderecoCobranca != viewModel.IdEnderecoPrincipal) {
                viewModel.IdEnderecoCobranca = viewModel.IdEnderecoPrincipal;
                instituicao.IdEnderecoCobranca = viewModel.IdEnderecoPrincipal;
            }
            else if (viewModel.EqualEnderecoCobranca == false && viewModel.IdEnderecoCobranca == viewModel.IdEnderecoPrincipal) {
                Endereco cobranca = viewModel.enderecoCobranca;
                db.Endereco.Add(cobranca);
                db.SaveChanges();
                instituicao.IdEnderecoCobranca = cobranca.IdEndereco;
            }
            else if (viewModel.EqualEnderecoCobranca == false) {
                //Atualizando endereço cobranca
                Endereco cobranca = viewModel.enderecoCobranca;
                db.Entry(cobranca).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            //Atualizando endereço principal
            Endereco principal = viewModel.enderecoPrincipal;
            db.Entry(principal).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            //Atualizando instituição
            (instituicao.IsMatriz, instituicao.IdMatriz) = HasMatriz_Update(instituicao.IdInstituicao);
            db.Entry(instituicao).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();           

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id) {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Instituicao instituicao = FindMinhaInstituicao(id);
            if (instituicao == null)
                return HttpNotFound();

            Endereco enderecoPrincipal = db.Endereco.Find(instituicao.IdEnderecoPrincipal);
            Endereco enderecoCobranca = null;
            if (instituicao.IdEnderecoPrincipal != instituicao.IdEnderecoCobranca)
                enderecoCobranca = db.Endereco.Find(instituicao.IdEnderecoCobranca);
            ViewBag.enderecoCobranca = enderecoCobranca;
            ViewBag.enderecoPrincipal = enderecoPrincipal;
            return View(instituicao);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Instituicao instituicao = db.Instituicao.Find(id);
            db.Instituicao.Remove(instituicao);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }

        //checa se a instituicao possui matriz ou é matriz e atualiza os campos (IsMatriz, IdMatriz)
        private (bool, int?) HasMatriz_Update(int id){
            Context db = new Context();
            Instituicao i = db.Instituicao.Find(id);
            db.Dispose();
            if(i.IsMatriz)
                return (true, null);
            else
                return (false, i.IdMatriz);
        }
    }
}
