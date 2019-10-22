using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaCertoForms.Models;
using TaCertoForms.Contexts;
using TaCertoForms.Attributes;

namespace TaCertoForms.Controllers{
    [SomenteLogado]
    public class PessoasController : Controller{
        private Context db = new Context();

        // GET: Pessoas
        public ActionResult Index(){
            List<ViewModelAluno> alunos = new List<ViewModelAluno>();
            foreach (var aluno in db.Pessoas.ToList())
            {                
                ViewModelAluno vmAluno = new ViewModelAluno() {
                    IdPessoa = aluno.IdPessoa,
                    Perfil   = aluno.Perfil,
                    Nome     = aluno.Nome,
                    CPF      = aluno.CPF,
                    Email    = aluno.Email                    
                };
                vmAluno.Instituicao.Add(db.Instituicaos.Find(aluno.IdInstituicao));
                alunos.Add(vmAluno);
            }
            return View(alunos);            
        }

        // GET: Pessoas/Details/5
        public ActionResult Details(int? id){
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Pessoa pessoa = db.Pessoas.Find(id);
            if (pessoa == null)
                return HttpNotFound();
            return View(pessoa);
        }

        // GET: Pessoas/Create
        public ActionResult Create(){
            List<Instituicao> list = db.Instituicaos.ToList();
            ViewBag.InstituicaoList = new SelectList(list, "IdInstituicao", "NomeFantasia");
            return View();
        }

        // POST: Pessoas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]        
        public ActionResult Create(Pessoa pessoa){            
            if (ModelState.IsValid){
                db.Pessoas.Add(pessoa);
                db.SaveChanges();
                return RedirectToAction("Edit", "Pessoas", new { id = pessoa.IdPessoa });
            }
            return View(pessoa);
        }

        // GET: Pessoas/Edit/5
        public ActionResult Edit(int? id){
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Pessoa pessoa = db.Pessoas.Find(id);
            List<Instituicao> list = db.Instituicaos.ToList();
            ViewBag.InstituicaoList = new SelectList(list, "IdInstituicao", "NomeFantasia");
            if (pessoa == null)
                return HttpNotFound();
            return View(pessoa);
        }

        // POST: Pessoas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPessoa,IdInstituicao,Perfil,Nome,CPF,Email,Senha")] Pessoa pessoa){
            if (ModelState.IsValid){
                db.Entry(pessoa).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pessoa);
        }

        // GET: Pessoas/Delete/5
        public ActionResult Delete(int? id){
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Pessoa pessoa = db.Pessoas.Find(id);
            if (pessoa == null)
                return HttpNotFound();
            return View(pessoa);
        }

        // POST: Pessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id){
            Pessoa pessoa = db.Pessoas.Find(id);
            db.Pessoas.Remove(pessoa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing){
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    }
}
