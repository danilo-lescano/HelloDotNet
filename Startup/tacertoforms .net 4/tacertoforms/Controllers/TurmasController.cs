using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using tacertoforms.Models;

namespace tacertoforms.Controllers{
    public class TurmasController : Controller{
        private Context db = new Context();

        // GET: Turmas
        public ActionResult Index(){
            List<Instituicao> list = db.Instituicaos.ToList();
            ViewBag.InstituicaoList = list;//new SelectList(list, "IdInstituicao", "NomeFantasia");
            return View(db.Turmas.ToList());
        }       

        // GET: Turmas/Details/5
        public ActionResult Details(int? id){
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Turma turma = db.Turmas.Find(id);
            if (turma == null)
                return HttpNotFound();
            Instituicao instituicao = db.Instituicaos.Find(turma.IdInstituicao);
            ViewBag.NomeFantasia = instituicao.NomeFantasia;
            return View(turma);
        }

        // GET: Turmas/Create
        public ActionResult Create(){
            List<Instituicao> list = db.Instituicaos.ToList();
            ViewBag.InstituicaoList = new SelectList(list, "IdInstituicao", "NomeFantasia");
            return View();
        }

        // POST: Turmas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTurma,IdInstituicao,Serie,Periodo")] Turma turma){
            if (ModelState.IsValid){
                db.Turmas.Add(turma);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(turma);
        }

        // GET: Turmas/Edit/5
        public ActionResult Edit(int? id){
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Turma turma = db.Turmas.Find(id);
            if (turma == null)
                return HttpNotFound();
            List<Instituicao> list = db.Instituicaos.ToList();
            ViewBag.InstituicaoList = new SelectList(list, "IdInstituicao", "NomeFantasia");
            return View(turma);
        }

        // POST: Turmas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTurma,IdInstituicao,Serie,Periodo")] Turma turma){
            if (ModelState.IsValid){
                db.Entry(turma).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(turma);
        }

        // GET: Turmas/Delete/5
        public ActionResult Delete(int? id){
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Turma turma = db.Turmas.Find(id);
            if (turma == null)
                return HttpNotFound();

            Instituicao instituicao = db.Instituicaos.Find(turma.IdInstituicao);
            ViewBag.NomeFantasia = instituicao.NomeFantasia;

            return View(turma);
        }

        // POST: Turmas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Turma turma = db.Turmas.Find(id);
            db.Turmas.Remove(turma);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //######################### AJAX Professores (Turmas Disciplinas) #########################
        //GET: Ajax Turmas
        [HttpGet]
        public ActionResult AjaxTurmas(int IdInstituicao)
        {
            List<Turma> turmas = db.Turmas.Where(x => x.IdInstituicao == IdInstituicao).ToList();
            ViewBag.TurmasList = new SelectList(turmas, "IdTurma", "Serie");
            return View();
        }

        //GET: Ajax Turmas Disciplinas
        [HttpGet]
        public ActionResult AjaxTurmasDisciplinas(int IdProfessor)
        {
            List<ViewModelDisciplina> disciplinaTurma = new List<ViewModelDisciplina>();
            List<TurmaDisciplinaProfessor> turmaDisciplinaProf = db.TurmaDisciplinaProfessors.Where(x => x.IdProfessor == IdProfessor).ToList();
            
            foreach (var td in turmaDisciplinaProf)
            {
                List<DisciplinaTurma> dt = db.DisciplinaTurmas.Where(x => x.IdDisciplinaTurma == td.IdDisciplinaTurma).ToList();
                foreach (var discTurm in dt)
                {
                    Disciplina disciplina = db.Disciplinas.Find(discTurm.IdDisciplina);
                    ViewModelDisciplina vmDisc = new ViewModelDisciplina() { Nome = disciplina.Nome, IdTurmaDisciplinaProfessor = td.IdTurmaDisciplinaProfessor};
                    vmDisc.Turmas.Add(db.Turmas.Find(discTurm.IdTurma));
                    disciplinaTurma.Add(vmDisc);
                }
            }            
            return View(disciplinaTurma);
        }        
    
        //POST: Ajax
        [HttpPost]
        public void SalvarTurmaDisciplina(TurmaDisciplinaProfessor turmaDisciplina)
        {
            if (ModelState.IsValid)
            {
                db.TurmaDisciplinaProfessors.Add(turmaDisciplina);
                db.SaveChanges();                
            }            
        }
        //Delete: Ajax
        [HttpPost]
        public void AjaxDesvincularTurmaDisciplina(int id)
        {
            TurmaDisciplinaProfessor tdp = db.TurmaDisciplinaProfessors.Find(id);
            db.TurmaDisciplinaProfessors.Remove(tdp);
            db.SaveChanges();            
        }
        //######################### AJAX Alunos #########################
        //POST: Ajax
        [HttpPost]
        public void SalvarTurmaAluno(TurmaAluno turmaAluno)
        {
            if (ModelState.IsValid)
            {
                db.TurmaAlunoes.Add(turmaAluno);
                db.SaveChanges();
            }
        }

        //GET: Ajax Turmas Disciplinas
        [HttpGet]
        public ActionResult AjaxTurmasAlunos(int IdPessoa)
        {            
            List<TurmaAluno> turmaAluno = db.TurmaAlunoes.Where(x => x.IdPessoa == IdPessoa).ToList();
            List<ViewModelAluno> aluno = new List<ViewModelAluno>().ToList();

            foreach (var ta in turmaAluno)
            {
                ViewModelAluno vmAluno = new ViewModelAluno() { IdTurmaAluno = ta.IdTurmaAluno };
                vmAluno.Turma.Add(db.Turmas.Find(ta.IdTurma));
                aluno.Add(vmAluno);
            }
            return View(aluno);
        }
        //Desvincular turma e aluno
        [HttpPost]
        public void AjaxDesvincularTurmaAluno(int id)
        {
            TurmaAluno ta = db.TurmaAlunoes.Find(id);
            db.TurmaAlunoes.Remove(ta);
            db.SaveChanges();
        }
        protected override void Dispose(bool disposing){
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    }
}