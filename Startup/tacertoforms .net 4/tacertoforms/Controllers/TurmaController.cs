using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;

using TaCertoForms.Attributes;
using TaCertoForms.Controllers.Base;
using TaCertoForms.Models;

namespace TaCertoForms.Controllers {
    [SomenteLogado]
    public class TurmaController : ControladoraBase {
        [Perfil(Perfil.Administrador)]
        public ActionResult Index() {
            List<Instituicao> list = Collection.InstituicaoList();
            ViewBag.InstituicaoList = list;
            return View(Collection.TurmaList());
        }

        [Perfil(Perfil.Administrador)]
        public ActionResult Create() {
            List<Instituicao> list = Collection.InstituicaoList();
            ViewBag.InstituicaoList = new SelectList(list, "IdInstituicao", "NomeFantasia");
            return View();
        }

        [HttpPost]
        [Perfil(Perfil.Administrador)]
        public ActionResult Create(Turma turma) {
            if(Collection.CreateTurma(turma) != null)
                return RedirectToAction("Index");
            return View(turma);
        }

        [Perfil(Perfil.Administrador)]
        public ActionResult Edit(int? id) {
            if(id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Turma turma = Collection.FindTurma(id);
            if(turma == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            List<Instituicao> list = Collection.InstituicaoList();
            ViewBag.InstituicaoList = new SelectList(list, "IdInstituicao", "NomeFantasia");
            return View(turma);
        }

        [HttpPost]
        [Perfil(Perfil.Administrador)]
        public ActionResult Edit(Turma turma) {
            if(Collection.EditTurma(turma) != null)
                return RedirectToAction("Index");
            return View(turma);
        }

        [Perfil(Perfil.Administrador)]
        public ActionResult Delete(int? id) {
            if(id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Turma turma = Collection.FindTurma(id);
            if(turma == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            Instituicao instituicao = Collection.FindInstituicao(turma.IdInstituicao);
            ViewBag.NomeFantasia = instituicao.NomeFantasia;

            return View(turma);
        }

        [Perfil(Perfil.Administrador)]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id) {
            Collection.DeleteTurma(id);
            return RedirectToAction("Index");
        }

        //######################### AJAX (Turma Disciplina) #########################
        [HttpGet]
        [Perfil(Perfil.Administrador, Perfil.Autor)]
        public ActionResult AjaxTurmas(int IdInstituicao) {
            List<Turma> turmas = Collection.TurmaList()?.Where(t => t.IdInstituicao == IdInstituicao).ToList();
            if(turmas == null) turmas = new List<Turma>();
            ViewBag.TurmasList = new SelectList(turmas, "IdTurma", "Serie");
            return View();
        }

        [HttpGet]
        [Perfil(Perfil.Administrador)]
        public ActionResult AjaxTurmasDisciplinas(int IdAutor) {
            List<ViewModelDisciplina> disciplinaTurma = new List<ViewModelDisciplina>();
            List<TurmaDisciplinaAutor> turmaDisciplinaProf = Collection.TurmaDisciplinaAutorList()?.Where(tda => tda.IdAutor == IdAutor).ToList();

            foreach(var td in turmaDisciplinaProf) {
                List<DisciplinaTurma> dt = Collection.DisciplinaTurmaList()?.Where(dta => dta.IdDisciplinaTurma == td.IdDisciplinaTurma).ToList();
                foreach(var discTurm in dt) {
                    Disciplina disciplina = Collection.FindDisciplina(discTurm.IdDisciplina);
                    ViewModelDisciplina vmDisc = new ViewModelDisciplina() { Nome = disciplina.Nome, IdTurmaDisciplinaAutor = td.IdTurmaDisciplinaAutor };
                    vmDisc.Turmas.Add(Collection.FindTurma(discTurm.IdTurma));
                    disciplinaTurma.Add(vmDisc);
                }
            }
            return View(disciplinaTurma);
        }

        [HttpPost]
        [Perfil(Perfil.Administrador)]
        public void SalvarTurmaDisciplina(TurmaDisciplinaAutor turmaDisciplina) {
            Collection.CreateTurmaDisciplinaAutor(turmaDisciplina);
        }

        [HttpPost]
        [Perfil(Perfil.Administrador)]
        public void AjaxDesvincularTurmaDisciplina(int id) {
            Collection.DeleteTurmaDisciplinaAutor(id);
        }

        //######################### AJAX Alunos #########################
        //POST: Ajax
        [HttpPost]
        [Perfil(Perfil.Administrador)]
        public void SalvarTurmaAluno(TurmaAluno turmaAluno) {
            Collection.CreateTurmaAluno(turmaAluno);
        }

        [HttpGet]
        [Perfil(Perfil.Administrador)]
        public ActionResult AjaxTurmasAlunos(int IdPessoa) {
            List<TurmaAluno> turmaAluno = Collection.TurmaAlunoList();
            if(turmaAluno != null) turmaAluno.Where(ta => ta.IdPessoa == IdPessoa).ToList();
            List<ViewModelPessoa> aluno = new List<ViewModelPessoa>();

            if(turmaAluno != null)
                foreach(var ta in turmaAluno) {
                    ViewModelPessoa vmAluno = new ViewModelPessoa() { IdTurmaAluno = ta.IdTurmaAluno };
                    vmAluno.Turma.Add(Collection.FindTurma(ta.IdTurma));
                    aluno.Add(vmAluno);
                }
            return View(aluno);
        }

        //Desvincular turma e aluno
        [HttpPost]
        [Perfil(Perfil.Administrador)]
        public void AjaxDesvincularTurmaAluno(int id) {
            Collection.DeleteTurmaAluno(id);
        }
    }
}