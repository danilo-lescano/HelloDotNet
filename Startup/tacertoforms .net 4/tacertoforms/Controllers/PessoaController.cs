using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaCertoForms.Models;
using TaCertoForms.Attributes;
using TaCertoForms.Controllers.Base;

namespace TaCertoForms.Controllers{
    [SomenteLogado]
    public class PessoaController : ControladoraBase{
        public ActionResult Index(){
            List<ViewModelPessoa> pessoas = new List<ViewModelPessoa>();
            foreach (var pessoa in CollectionMatriz.PessoaList()){
                ViewModelPessoa vmPessoa = new ViewModelPessoa();
                vmPessoa.Pessoa = pessoa;
                Instituicao i = CollectionMatriz.FindInstituicao(pessoa.IdInstituicao);
                if(i != null){
                    vmPessoa.Instituicao.Add(i);
                    pessoas.Add(vmPessoa);
                }
            }
            return View(pessoas);
        }

        public ActionResult Create(){
            List<Instituicao> list = CollectionMatriz.InstituicaoList();
            if(list == null)
                list = new List<Instituicao>();
            ViewBag.InstituicaoList = new SelectList(list, "IdInstituicao", "NomeFantasia");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Pessoa pessoa){
            pessoa = CollectionMatriz.CreatePessoa(pessoa);
            if(pessoa != null)
                return RedirectToAction("Edit", "Pessoa", new { id = pessoa.IdPessoa });
            return View(pessoa);
        }

        public ActionResult Edit(int? id){
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Pessoa pessoa = CollectionMatriz.FindPessoa(id);
            if(pessoa == null) return HttpNotFound();
            List<Instituicao> list = CollectionMatriz.InstituicaoList();
            ViewBag.InstituicaoList = new SelectList(list, "IdInstituicao", "NomeFantasia");
            if (pessoa == null)
                return HttpNotFound();
            
            ViewBag.Midia = db.Midia.Where(x => x.IdOrigem == id && x.Tabela == "Pessoa").FirstOrDefault<Midia>();  
            return View(pessoa);
        }

        [HttpPost]
        public ActionResult Edit(Pessoa pessoa){
            if (CollectionMatriz.EditPessoa(pessoa) != null)
                return RedirectToAction("Index");
            return View(pessoa);
        }

        public ActionResult Delete(int? id){
            Pessoa pessoa = CollectionMatriz.FindPessoa(id);
            if (pessoa == null)
                return HttpNotFound();
            return View(pessoa);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id){
            CollectionMatriz.DeletePessoa(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing){
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    }
}