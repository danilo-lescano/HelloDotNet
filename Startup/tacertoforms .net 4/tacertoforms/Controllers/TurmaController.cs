using System.Net;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using TaCertoForms.Models;
using TaCertoForms.Attributes;
using TaCertoForms.Controllers.Base;

namespace TaCertoForms.Controllers{
    [SomenteLogado]
    public class TurmaController : ControladoraBase{
        [Perfil(Perfil.Administrador)]
        public ActionResult Index(){
            List<Instituicao> list = Collection.InstituicaoList();
            ViewBag.InstituicaoList = list;
            return View(Collection.TurmaList());
        }

        [Perfil(Perfil.Administrador)]
        public ActionResult Create(){
            List<Instituicao> list = Collection.InstituicaoList();
            ViewBag.InstituicaoList = new SelectList(list, "IdInstituicao", "NomeFantasia");
            return View();
        }

        [HttpPost]
        [Perfil(Perfil.Administrador)]
        public ActionResult Create(Turma turma){
            if(Collection.CreateTurma(turma) != null)
                return RedirectToAction("Index");
            return View(turma);
        }

        [Perfil(Perfil.Administrador)]
        public ActionResult Edit(int? id){
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Turma turma = Collection.FindTurma(id);
            if (turma == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            List<Instituicao> list = Collection.InstituicaoList();
            ViewBag.InstituicaoList = new SelectList(list, "IdInstituicao", "NomeFantasia");
            return View(turma);
        }

        [Perfil(Perfil.Administrador)]
        [HttpPost]
        public ActionResult Edit(Turma turma){            
            if(Collection.EditTurma(turma) != null)
                return RedirectToAction("Index");
            return View(turma);
        }

        [Perfil(Perfil.Administrador)]
        public ActionResult Delete(int? id){
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Turma turma = Collection.FindTurma(id);
            if (turma == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            Instituicao instituicao = Collection.FindInstituicao(turma.IdInstituicao);
            ViewBag.NomeFantasia = instituicao.NomeFantasia;

            return View(turma);
        }

        [Perfil(Perfil.Administrador)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Collection.DeleteTurma(id);            
            return RedirectToAction("Index");
        }

        //######################### AJAX (Turma Disciplina) #########################
        [Perfil(Perfil.Administrador)]
        [HttpGet]
        public ActionResult AjaxTurmas(int IdInstituicao){
            List<Turma> turmas = Collection.TurmaList().Where(t => t.IdInstituicao == IdInstituicao).ToList();
            ViewBag.TurmasList = new SelectList(turmas, "IdTurma", "Serie");
            return View();
        }

        [HttpGet]
        [Perfil(Perfil.Administrador)]
        public ActionResult AjaxTurmasDisciplinas(int IdAutor){
            List<ViewModelDisciplina> disciplinaTurma = new List<ViewModelDisciplina>();
            List<TurmaDisciplinaAutor> turmaDisciplinaProf = Collection.TurmaDisciplinaAutorList().Where(x => x.IdAutor == IdAutor).ToList();
            
            foreach (var td in turmaDisciplinaProf){
                List<DisciplinaTurma> dt = Collection.DisciplinaTurmaList().Where(x => x.IdDisciplinaTurma == td.IdDisciplinaTurma).ToList();
                foreach (var discTurm in dt){
                    Disciplina disciplina = Collection.FindDisciplina(discTurm.IdDisciplina);
                    ViewModelDisciplina vmDisc = new ViewModelDisciplina() { Nome = disciplina.Nome, IdTurmaDisciplinaAutor = td.IdTurmaDisciplinaAutor};
                    vmDisc.Turmas.Add(Collection.FindTurma(discTurm.IdTurma));
                    disciplinaTurma.Add(vmDisc);
                }
            }            
            return View(disciplinaTurma);
        }

        [HttpPost]
        [Perfil(Perfil.Administrador)]
        public void SalvarTurmaDisciplina(TurmaDisciplinaAutor turmaDisciplina){
            Collection.CreateTurmaDisciplinaAutor(turmaDisciplina);
        }

        [HttpPost]
        [Perfil(Perfil.Administrador)]
        public void AjaxDesvincularTurmaDisciplina(int id){
            Collection.DeleteTurmaDisciplinaAutor(id);
        }

        //######################### AJAX Alunos #########################
        //POST: Ajax
        [HttpPost]
        [Perfil(Perfil.Administrador)]
        public void SalvarTurmaAluno(TurmaAluno turmaAluno){
            Collection.CreateTurmaAluno(turmaAluno);
        }

        [HttpGet]
        [Perfil(Perfil.Administrador)]
        public ActionResult AjaxTurmasAlunos(int IdPessoa){            
            List<TurmaAluno> turmaAluno = Collection.TurmaAlunoList().Where(ta => ta.IdPessoa == IdPessoa).ToList();
            List<ViewModelPessoa> aluno = new List<ViewModelPessoa>().ToList();

            foreach (var ta in turmaAluno){
                ViewModelPessoa vmAluno = new ViewModelPessoa() { IdTurmaAluno = ta.IdTurmaAluno };
                vmAluno.Turma.Add(Collection.FindTurma(ta.IdTurma));
                aluno.Add(vmAluno);
            }
            return View(aluno);
        }

        //Desvincular turma e aluno
        [HttpPost]
        [Perfil(Perfil.Administrador)]
        public void AjaxDesvincularTurmaAluno(int id){
            Collection.DeleteTurmaAluno(id);
        }        
    }
}