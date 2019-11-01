using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TaCertoForms.Contexts;
using TaCertoForms.Models;
using TaCertoForms.Attributes;
using TaCertoForms.Controllers.Base;

namespace TaCertoForms.Controllers{
    [SomenteLogado]
    public class AtividadeController : ControladoraBase {
        [Perfil(Perfil.Autor)]
        public ActionResult Index(){
            List<Atividade> atividades = Collection.AtividadeList();
            List<ViewModelAtividade> vmAtividades = new List<ViewModelAtividade>();
            foreach (var a in atividades){
                ViewModelAtividade vma = new ViewModelAtividade();
                vma.Atividade = a;
                (vma.nome_da_materia, vma.nome_da_turma) = GetNomeTurmaNomeDisciplina(a.IdTurmaDisciplinaAutor);
                vmAtividades.Add(vma);
            }
            return View(vmAtividades);
        }

        [Perfil(Perfil.Autor)]
        public ActionResult Create() {            
            return View();
        }

        [HttpPost]
        [Perfil(Perfil.Autor)]
        public ActionResult Create(ViewModelAtividade vmAtividade){
            Atividade atividade = vmAtividade.Atividade;            
            TurmaDisciplinaAutor tda_aux = db.TurmaDisciplinaAutor.Where(tda => tda.IdAutor == (int)Session["IdPessoa"] && tda.IdDisciplinaTurma == vmAtividade.IdDisciplinaTurma).FirstOrDefault();
            atividade.IdTurmaDisciplinaAutor = tda_aux.IdTurmaDisciplinaAutor;           

            Collection.CreateAtividade(atividade);

            foreach (Questao q in vmAtividade.Questoes){
                q.IdAtividade = atividade.IdAtividade;
                db.Questao.Add(q);
                db.SaveChanges();
            }
            return RedirectToAction("Edit", new { id = atividade.IdAtividade});
        }

        [Perfil(Perfil.Autor)]
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

            ViewBag.Instituicao = db.Instituicao.Find((int)Session["IdInstituicao"]);
            //Buscando Turma
            TurmaDisciplinaAutor tda = db.TurmaDisciplinaAutor.Find(vmAtividade.IdTurmaDisciplinaAutor);
            DisciplinaTurma dt = db.DisciplinaTurma.Find(tda.IdDisciplinaTurma);
            Turma turma = db.Turma.Find(dt.IdTurma);
            Disciplina disciplina = db.Disciplina.Find(dt.IdDisciplina);
            
            ViewBag.Turma = turma;
            ViewBag.Disciplina = disciplina;

            return View(vmAtividade);
        }

        [HttpPost]
        [Perfil(Perfil.Autor)]
        public ActionResult Edit(ViewModelAtividade vmAtividade){
            Atividade atividade = vmAtividade.Atividade; 
            if(atividade != null && atividade.IdAtividade != 0){
                db.Entry(atividade).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(atividade);
        }

        [Perfil(Perfil.Autor)]
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
        [Perfil(Perfil.Autor)]
        public ActionResult DeleteConfirmed(int id){
            Atividade atividade = db.Atividade.Find(id);
            db.Atividade.Remove(atividade);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        //Dado um IdTurmaDisciplinaAutor (tda_id) devolve nome de disciplina e turma respectivamente
        private (string, string) GetNomeTurmaNomeDisciplina(int tda_id){
            Context db = new Context();
            TurmaDisciplinaAutor tda = db.TurmaDisciplinaAutor.Find(tda_id);
            if(tda == null) return ("", "");
            DisciplinaTurma dt = db.DisciplinaTurma.Find(tda.IdDisciplinaTurma);
            if(dt == null) return ("", "");
            Turma t = db.Turma.Find(dt.IdTurma);
            if(t == null) return ("", "");
            Disciplina d = db.Disciplina.Find(dt.IdDisciplina);
            if(d == null) return ("", "");
            db.Dispose();
            return (d.Nome, t.Serie);
        }
    }
}