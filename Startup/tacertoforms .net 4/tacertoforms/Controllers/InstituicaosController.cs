using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaCertoForms.Models;
using TaCertoForms.Attributes;
using TaCertoForms.Controllers.Base;

namespace TaCertoForms.Controllers{
   // [SomenteLogado]
    public class InstituicaosController : ControladoraBase {
        
        // GET: Instituicaos
        public ActionResult Index() {            
            return View(db.Instituicao.ToList());
        }
        // GET: Instituicaos/Create
        public ActionResult Create() {
            return View();
        }

        // POST: Instituicaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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
            db.Instituicao.Add(instituicao);
            db.SaveChanges();

            //Salvando Mídia (Logo da Empresa)            
            //HttpFileCollectionBase files = Request.Files;
            //MidiasController.Save(files, instituicao.IdInstituicao, "Instituicaos");

            return RedirectToAction("Index");
        }

        // GET: Instituicaos/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ViewModelInstituicao vmInstituicao = new ViewModelInstituicao();
            Instituicao instituicao = db.Instituicao.Find(id);
            if (instituicao == null)
                return HttpNotFound();
            vmInstituicao.instituicao = db.Instituicao.Find(id);

            Endereco enderecoPrincipal = db.Endereco.Find(instituicao.IdEnderecoPrincipal);
            Endereco enderecoCobranca = null;
            if (instituicao.IdEnderecoPrincipal != instituicao.IdEnderecoCobranca)
            {
                enderecoCobranca = db.Endereco.Find(instituicao.IdEnderecoCobranca);
            }
            ViewBag.enderecoCobranca = enderecoCobranca;
            ViewBag.enderecoPrincipal = enderecoPrincipal;

            vmInstituicao.Midia = db.Midia.Where(x => x.IdOrigem == id && x.Tabela == "Instituicao").FirstOrDefault<Midia>();
                        
            return View(vmInstituicao);
        }

        // POST: Instituicaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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
            db.Entry(instituicao).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();           

            return RedirectToAction("Index");
        }

        // GET: Instituicaos/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Instituicao instituicao = db.Instituicao.Find(id);
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

        // POST: Instituicaos/Delete/5
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
    }
}
