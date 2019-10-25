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
    public class DisciplinaController : ControladoraBase{       

        public ActionResult Index(){
            List<ViewModelDisciplina> disciplinas = new List<ViewModelDisciplina>();
            foreach (var disc in db.Disciplina.ToList()){
                ViewModelDisciplina vmDisc = new ViewModelDisciplina(){ IdDisciplina = disc.IdDisciplina, Nome = disc.Nome, Descricao = disc.Descricao };
                List<DisciplinaTurma> aux = db.DisciplinaTurma.Where(dt => dt.IdDisciplina == disc.IdDisciplina).ToList();

                foreach (var discTurm in aux)
                    vmDisc.Turmas.Add(db.Turma.Find(discTurm.IdTurma));
                disciplinas.Add(vmDisc);
            }
            return View(disciplinas);
        }

        //GET: Ajax
        [HttpGet]
        public ActionResult AjaxDisciplinas(int IdTurma){
            List<ViewModelDisciplina> disciplinas = new List<ViewModelDisciplina>();
            List<DisciplinaTurma> disciplinasTurma = db.DisciplinaTurma.Where(x => x.IdTurma == IdTurma).ToList();
            foreach (var disciplinaTurma in disciplinasTurma)
            {
                Disciplina disciplina = db.Disciplina.Find(disciplinaTurma.IdDisciplina);                
                ViewModelDisciplina vmDisc = new ViewModelDisciplina() { IdDisciplinaTurma = disciplinaTurma.IdDisciplinaTurma, Nome = disciplina.Nome};
                disciplinas.Add(vmDisc);
            }
            ViewBag.DisciplinasList = new SelectList(disciplinas, "IdDisciplinaTurma", "Nome");
            return View();
        }

        public ActionResult Details(int? id){
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Disciplina disciplina = db.Disciplina.Find(id);
            if (disciplina == null)
                return HttpNotFound();
            return View(disciplina);
        }

        public ActionResult Create(){
            ViewBag.turmas = db.Turma.ToList();
            ViewBag.InstituicaoList = db.Instituicao.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(ViewModelDisciplina vmDisciplina){
            Disciplina disciplina = vmDisciplina.Disciplina;
            db.Disciplina.Add(disciplina);
            db.SaveChanges();
            
            string[] idTurmas = vmDisciplina.idTurmas.Split(';');
            foreach (string t in idTurmas){
                db.DisciplinaTurma.Add(new DisciplinaTurma(){ IdDisciplina = disciplina.IdDisciplina, IdTurma = int.Parse(t) });
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id){
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Disciplina disciplina = db.Disciplina.Find(id);
            if (disciplina == null)
                return HttpNotFound();

            ViewModelDisciplina viewModelDisciplina = new ViewModelDisciplina();
            viewModelDisciplina.Disciplina = disciplina;

            List<DisciplinaTurma> aux = db.DisciplinaTurma.Where(dt => dt.IdDisciplina == viewModelDisciplina.IdDisciplina).ToList();
            foreach (var discTurm in aux)
                viewModelDisciplina.Turmas.Add(db.Turma.Find(discTurm.IdTurma));
            viewModelDisciplina.EncherTurmas();

            ViewBag.turmas = db.Turma.ToList();
            ViewBag.InstituicaoList = db.Instituicao.ToList();
            
            return View(viewModelDisciplina);
        }

        [HttpPost]
        public ActionResult Edit(ViewModelDisciplina vmDisciplina){
            Disciplina disciplina = vmDisciplina.Disciplina;
            db.Entry(disciplina).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            string[] idTurmas = vmDisciplina.idTurmas != null ? vmDisciplina.idTurmas.Split(';') : new string[0];
            foreach (var id in idTurmas)
                vmDisciplina.Turmas.Add(db.Turma.Find(int.Parse(id)));
 
            List<DisciplinaTurma> dts = db.DisciplinaTurma.Where(dt => dt.IdDisciplina == vmDisciplina.IdDisciplina).ToList();
            List<Turma> turmasBanco = new List<Turma>();
            foreach (var aux in dts)
                turmasBanco.Add(db.Turma.Find(aux.IdTurma));

            for(int i = vmDisciplina.Turmas.Count - 1; i >= 0; i--){
                bool flag = false;
                for (int j = turmasBanco.Count - 1; j >= 0; j--){
                    if(turmasBanco[j].IdTurma == vmDisciplina.Turmas[i].IdTurma){
                        flag = true;
                        turmasBanco.RemoveAt(j);
                        break;
                    }
                }
                if(!flag){
                    db.DisciplinaTurma.Add(new DisciplinaTurma() {IdDisciplina = disciplina.IdDisciplina, IdTurma = vmDisciplina.Turmas[i].IdTurma});
                    db.SaveChanges();
                }
            }
            foreach (var item in turmasBanco){
                DisciplinaTurma dt = db.DisciplinaTurma.Where(aux => aux.IdDisciplina == vmDisciplina.IdDisciplina && aux.IdTurma == item.IdTurma).Single();
                if(dt != null){
                    db.DisciplinaTurma.Remove(dt);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id){
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Disciplina disciplina = db.Disciplina.Find(id);
            if (disciplina == null)
                return HttpNotFound();

            ViewModelDisciplina viewModelDisciplina = new ViewModelDisciplina();
            viewModelDisciplina.Disciplina = disciplina;

            List<DisciplinaTurma> aux = db.DisciplinaTurma.Where(dt => dt.IdDisciplina == viewModelDisciplina.IdDisciplina).ToList();
            foreach (var discTurm in aux)
                viewModelDisciplina.Turmas.Add(db.Turma.Find(discTurm.IdTurma));
            viewModelDisciplina.EncherTurmas();

            ViewBag.turmas = db.Turma.ToList();
            ViewBag.InstituicaoList = db.Instituicao.ToList();
            
            return View(viewModelDisciplina);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id){
            Disciplina disciplina = db.Disciplina.Find(id);
            db.Disciplina.Remove(disciplina);
            db.SaveChanges();
            List<DisciplinaTurma> disciplinaTurmas = db.DisciplinaTurma.Where(dt => dt.IdDisciplina == id).ToList();
            foreach (var dt in disciplinaTurmas){
                db.DisciplinaTurma.Remove(dt);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing){
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    }
}