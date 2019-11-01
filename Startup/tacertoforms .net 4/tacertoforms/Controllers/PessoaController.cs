using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using TaCertoForms.Models;
using TaCertoForms.Attributes;
using TaCertoForms.Controllers.Base;

namespace TaCertoForms.Controllers{
    [SomenteLogado]
    public class PessoaController : ControladoraBase{
        [Perfil(Perfil.Administrador)]
        public ActionResult Index(){
            List<ViewModelPessoa> pessoas = new List<ViewModelPessoa>();
            foreach (var pessoa in Collection.PessoaList()){
                ViewModelPessoa vmPessoa = new ViewModelPessoa();
                vmPessoa.Pessoa = pessoa;
                Instituicao i = Collection.FindInstituicao(pessoa.IdInstituicao);
                if(i != null){
                    vmPessoa.Instituicao.Add(i);
                    pessoas.Add(vmPessoa);
                }
            }
            return View(pessoas);
        }
        [Perfil(Perfil.Administrador)]
        public ActionResult Create(){
            List<Instituicao> list = Collection.InstituicaoList();
            if(list == null)
                list = new List<Instituicao>();
            ViewBag.InstituicaoList = new SelectList(list, "IdInstituicao", "NomeFantasia");
            return View();
        }
        [Perfil(Perfil.Administrador)]
        [HttpPost]
        public ActionResult Create(Pessoa pessoa){
            pessoa = Collection.CreatePessoa(pessoa);
            if(pessoa != null)
                return RedirectToAction("Edit", "Pessoa", new { id = pessoa.IdPessoa });
            return View(pessoa);
        }

        public ActionResult Edit(int? id){
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Pessoa pessoa = Collection.FindPessoa(id);
            if(pessoa == null) return HttpNotFound();
            List<Instituicao> list = Collection.InstituicaoList();
            ViewBag.InstituicaoList = new SelectList(list, "IdInstituicao", "NomeFantasia");
            if (pessoa == null)
                return HttpNotFound();
            
            ViewBag.Midia = Collection.FindMidia(id, "Pessoa");  
            return View(pessoa);
        }

        [HttpPost]
        public ActionResult Edit(Pessoa pessoa){
            if (Collection.EditPessoa(pessoa) != null)
                return RedirectToAction("Index");
            return View(pessoa);
        }
        [Perfil(Perfil.Administrador)]
        public ActionResult Delete(int? id){
            Pessoa pessoa = Collection.FindPessoa(id);
            if (pessoa == null)
                return HttpNotFound();
            return View(pessoa);
        }
        [Perfil(Perfil.Administrador)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id){
            Collection.DeletePessoa(id);
            return RedirectToAction("Index");
        }
    }
}