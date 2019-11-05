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
            Atividade atividade = new Atividade();            
            List<TurmaDisciplinaAutor> tda = Collection.TurmaDisciplinaAutorList();            

            TurmaDisciplinaAutor turmaDisciplinaAutor = tda?.Where(x => x.IdDisciplinaTurma == vmAtividade.IdDisciplinaTurma).FirstOrDefault();
            vmAtividade.IdTurmaDisciplinaAutor = turmaDisciplinaAutor.IdTurmaDisciplinaAutor;            
            atividade = Collection.CreateAtividade(vmAtividade.Atividade);       
            
            return RedirectToAction("Edit", new { id = atividade.IdAtividade});
        }

        [Perfil(Perfil.Autor)]
        public ActionResult Edit(int? id){
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ViewModelAtividade vmAtividade = new ViewModelAtividade();
            vmAtividade.Atividade = Collection.FindAtividade(id);            
            vmAtividade.setPeriodo();

                    
            //Buscando Turma e Disciplina
            TurmaDisciplinaAutor tda = Collection.FindTurmaDisciplinaAutor(vmAtividade.IdTurmaDisciplinaAutor);
            if (tda == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            DisciplinaTurma dt = Collection.FindDisciplinaTurma(tda.IdDisciplinaTurma);
            if (dt == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            Turma turma = Collection.FindTurma(dt.IdTurma);
            if (turma == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            Disciplina disciplina = Collection.FindDisciplina(dt.IdDisciplina);
            if (disciplina == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound);

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