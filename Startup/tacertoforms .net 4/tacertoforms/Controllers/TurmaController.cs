using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TaCertoForms.Models;
using TaCertoForms.Attributes;
using TaCertoForms.Controllers.Base;

namespace TaCertoForms.Controllers{
    [SomenteLogado]
    public class TurmaController : ControladoraBase{
        public ActionResult Index(){
            List<Instituicao> list = CollectionMatriz.InstituicaoList();
            ViewBag.InstituicaoList = list;
            return View(CollectionMatriz.TurmaList());
        }               
        public ActionResult Create(){
            List<Instituicao> list = CollectionMatriz.InstituicaoList();
            ViewBag.InstituicaoList = new SelectList(list, "IdInstituicao", "NomeFantasia");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Turma turma){
            if (ModelState.IsValid) {
                CollectionMatriz.CreateTurma(turma);                
                return RedirectToAction("Index");
            }
            return View(turma);
        }

        public ActionResult Edit(int? id){
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Turma turma = CollectionMatriz.FindTurma(id);
            if (turma == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            List<Instituicao> list = CollectionMatriz.InstituicaoList();
            ViewBag.InstituicaoList = new SelectList(list, "IdInstituicao", "NomeFantasia");
            return View(turma);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Turma turma){            
            if(CollectionMatriz.EditTurma(turma) != null)
            {
                return RedirectToAction("Index");
            }
            return View(turma);
        }

        public ActionResult Delete(int? id){
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Turma turma = CollectionMatriz.FindTurma(id);
            if (turma == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            Instituicao instituicao = CollectionMatriz.FindInstituicao(turma.IdInstituicao);
            ViewBag.NomeFantasia = instituicao.NomeFantasia;

            return View(turma);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            CollectionMatriz.DeleteTurma(id);            
            return RedirectToAction("Index");
        }

        //######################### AJAX (Turma Disciplina) #########################
        [HttpGet]
        public ActionResult AjaxTurmas(int IdInstituicao){
            List<Turma> turmas = db.Turma.Where(x => x.IdInstituicao == IdInstituicao).ToList();
            ViewBag.TurmasList = new SelectList(turmas, "IdTurma", "Serie");
            return View();
        }

        [HttpGet]
        public ActionResult AjaxTurmasDisciplinas(int IdAutor){
            List<ViewModelDisciplina> disciplinaTurma = new List<ViewModelDisciplina>();
            List<TurmaDisciplinaAutor> turmaDisciplinaProf = db.TurmaDisciplinaAutor.Where(x => x.IdAutor == IdAutor).ToList();
            
            foreach (var td in turmaDisciplinaProf){
                List<DisciplinaTurma> dt = db.DisciplinaTurma.Where(x => x.IdDisciplinaTurma == td.IdDisciplinaTurma).ToList();
                foreach (var discTurm in dt){
                    Disciplina disciplina = db.Disciplina.Find(discTurm.IdDisciplina);
                    ViewModelDisciplina vmDisc = new ViewModelDisciplina() { Nome = disciplina.Nome, IdTurmaDisciplinaAutor = td.IdTurmaDisciplinaAutor};
                    vmDisc.Turmas.Add(db.Turma.Find(discTurm.IdTurma));
                    disciplinaTurma.Add(vmDisc);
                }
            }            
            return View(disciplinaTurma);
        }        
    
        [HttpPost]
        public void SalvarTurmaDisciplina(TurmaDisciplinaAutor turmaDisciplina){
            if (ModelState.IsValid){
                db.TurmaDisciplinaAutor.Add(turmaDisciplina);
                db.SaveChanges();                
            }            
        }
        [HttpPost]
        public void AjaxDesvincularTurmaDisciplina(int id){
            TurmaDisciplinaAutor tdp = db.TurmaDisciplinaAutor.Find(id);
            db.TurmaDisciplinaAutor.Remove(tdp);
            db.SaveChanges();            
        }
        //######################### AJAX Alunos #########################
        //POST: Ajax
        [HttpPost]
        public void SalvarTurmaAluno(TurmaAluno turmaAluno){
            if (ModelState.IsValid){
                db.TurmaAluno.Add(turmaAluno);
                db.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult AjaxTurmasAlunos(int IdPessoa){            
            List<TurmaAluno> turmaAluno = db.TurmaAluno.Where(x => x.IdPessoa == IdPessoa).ToList();
            List<ViewModelPessoa> aluno = new List<ViewModelPessoa>().ToList();

            foreach (var ta in turmaAluno){
                ViewModelPessoa vmAluno = new ViewModelPessoa() { IdTurmaAluno = ta.IdTurmaAluno };
                vmAluno.Turma.Add(db.Turma.Find(ta.IdTurma));
                aluno.Add(vmAluno);
            }
            return View(aluno);
        }
        //Desvincular turma e aluno
        [HttpPost]
        public void AjaxDesvincularTurmaAluno(int id){
            TurmaAluno ta = db.TurmaAluno.Find(id);
            db.TurmaAluno.Remove(ta);
            db.SaveChanges();
        }
        protected override void Dispose(bool disposing){
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    }
}