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
    public class PessoasController : ControladoraBase
    {
        // GET: Pessoas
        public ActionResult Index(){
            List<ViewModelAluno> alunos = new List<ViewModelAluno>();
            foreach (var aluno in db.Pessoa.ToList())
            {                
                ViewModelAluno vmAluno = new ViewModelAluno() {
                    IdPessoa = aluno.IdPessoa,
                    Perfil   = aluno.Perfil,
                    Nome     = aluno.Nome,
                    CPF      = aluno.CPF,
                    Email    = aluno.Email                    
                };
                vmAluno.Instituicao.Add(db.Instituicao.Find(aluno.IdInstituicao));
                alunos.Add(vmAluno);
            }
            return View(alunos);            
        }

        // GET: Pessoas/Details/5
        public ActionResult Details(int? id){
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Pessoa pessoa = db.Pessoa.Find(id);
            if (pessoa == null)
                return HttpNotFound();
            return View(pessoa);
        }

        // GET: Pessoas/Create
        public ActionResult Create(){
            List<Instituicao> list = db.Instituicao.ToList();
            ViewBag.InstituicaoList = new SelectList(list, "IdInstituicao", "NomeFantasia");
            return View();
        }

        // POST: Pessoas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]        
        public ActionResult Create(Pessoa pessoa){            
            if (ModelState.IsValid){
                db.Pessoa.Add(pessoa);
                db.SaveChanges();

                //Salvando M�dia (Logo da Empresa)
                //HttpFileCollectionBase files = Request.Files;
                //MidiasController.Save(files, pessoa.IdPessoa, "Pessoas");

                return RedirectToAction("Edit", "Pessoas", new { id = pessoa.IdPessoa });
            }
            return View(pessoa);
        }

        // GET: Pessoas/Edit/5
        public ActionResult Edit(int? id){
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Pessoa pessoa = db.Pessoa.Find(id);
            List<Instituicao> list = db.Instituicao.ToList();
            ViewBag.InstituicaoList = new SelectList(list, "IdInstituicao", "NomeFantasia");
            if (pessoa == null)
                return HttpNotFound();
            Midia midia = db.Midia.Where(x => x.IdOrigem == id && x.Tabela == "Pessoas").FirstOrDefault<Midia>();            
            ViewBag.Midia = midia;            
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
            Pessoa pessoa = db.Pessoa.Find(id);
            if (pessoa == null)
                return HttpNotFound();
            return View(pessoa);
        }

        // POST: Pessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id){
            Pessoa pessoa = db.Pessoa.Find(id);
            db.Pessoa.Remove(pessoa);
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
