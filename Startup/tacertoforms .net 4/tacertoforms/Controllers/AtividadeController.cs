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
    public class AtividadeController : ControladoraBase {        

        [Perfil(Perfil.Administrador, Perfil.Autor)]
        public ActionResult Index(){
            List<Atividade> atividades = db.Atividade.ToList();
            List<ViewModelAtividade> vmAtividades = new List<ViewModelAtividade>();
            foreach (var a in atividades){
                ViewModelAtividade vma = new ViewModelAtividade();
                vma.Atividade = a;
                TurmaDisciplinaAutor tda = db.TurmaDisciplinaAutor.Find(a.IdTurmaDisciplinaAutor);
                DisciplinaTurma dt = db.DisciplinaTurma.Find(tda.IdDisciplinaTurma);
                Turma t = db.Turma.Find(dt.IdTurma);
                Disciplina d = db.Disciplina.Find(dt.IdDisciplina);
                vma.nome_da_materia = d.Nome;
                vma.nome_da_turma = t.Serie;
                vmAtividades.Add(vma);
            }
            return View(vmAtividades);
        }

        public ActionResult Create(){
            List<Instituicao> list = db.Instituicao.ToList();
            ViewBag.InstituicaoList = new SelectList(list, "IdInstituicao", "NomeFantasia");
            return View();
        }

        [HttpPost]
        public ActionResult Create(ViewModelAtividade vmAtividade){
            Atividade atividade = vmAtividade.Atividade;
            int IdUsuario = (int)Session["IdPessoa"];
            TurmaDisciplinaAutor tda_aux = db.TurmaDisciplinaAutor.Where(tda => tda.IdAutor == IdUsuario && tda.IdDisciplinaTurma == vmAtividade.IdDisciplinaTurma).FirstOrDefault();
            atividade.IdTurmaDisciplinaAutor = tda_aux.IdTurmaDisciplinaAutor;
            db.Atividade.Add(atividade);
            db.SaveChanges();
            foreach (Questao q in vmAtividade.Questoes){
                q.IdAtividade = atividade.IdAtividade;
                db.Questao.Add(q);
                db.SaveChanges();
            }
            return RedirectToAction("Edit", new { id = atividade.IdAtividade});
        }

        public ActionResult Edit(int? id){
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            ViewModelAtividade vmAtividade = new ViewModelAtividade();
            vmAtividade.Atividade = db.Atividade.Find(id);
            vmAtividade.Questoes = db.Questao.Where(q => q.IdAtividade == vmAtividade.IdAtividade).ToList();
            if(vmAtividade.Questoes == null)
                vmAtividade.Questoes = new List<Questao>();
            if (vmAtividade.IdAtividade == 0)
                return HttpNotFound();
            vmAtividade.setPeriodo();
            return View(vmAtividade);
        }

        [HttpPost]
        public ActionResult Edit(ViewModelAtividade vmAtividade){
            Atividade atividade = vmAtividade.Atividade; 
            if(atividade != null && atividade.IdAtividade != 0){
                db.Entry(atividade).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(atividade);
        }

        public ActionResult Delete(int? id){
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Atividade atividade = db.Atividade.Find(id);
            if (atividade == null)
                return HttpNotFound();
            return View(atividade);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id){
            Atividade atividade = db.Atividade.Find(id);
            db.Atividade.Remove(atividade);
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