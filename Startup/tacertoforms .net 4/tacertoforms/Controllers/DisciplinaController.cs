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
    public class DisciplinaController : ControladoraBase{
        [Perfil(Perfil.Administrador)]
        public ActionResult Index(){
            List<ViewModelDisciplina> disciplinas = new List<ViewModelDisciplina>();
            List<Disciplina> disciplinasBanco = Collection.DisciplinaList();
            List<DisciplinaTurma> disciplinaTurmaList = Collection.DisciplinaTurmaList();
            if (disciplinasBanco != null) { 
                foreach (var disc in disciplinasBanco){
                    ViewModelDisciplina vmDisc = new ViewModelDisciplina(){ IdDisciplina = disc.IdDisciplina, Nome = disc.Nome, Descricao = disc.Descricao };
                    List<DisciplinaTurma> aux = disciplinaTurmaList.Where(dt => dt.IdDisciplina == disc.IdDisciplina).ToList();

                    foreach (var discTurm in aux)
                        vmDisc.Turmas.Add(Collection.FindTurma(discTurm.IdTurma));
                    disciplinas.Add(vmDisc);
                }
            }
            return View(disciplinas);
        }

        //GET: Ajax
        [HttpGet]
        public ActionResult AjaxDisciplinas(int IdTurma){
            List<ViewModelDisciplina> disciplinas = new List<ViewModelDisciplina>();
            List<DisciplinaTurma> disciplinasTurma = Collection.DisciplinaTurmaList().Where(x => x.IdTurma == IdTurma).ToList();
            if(disciplinasTurma != null) { 
                foreach (var disciplinaTurma in disciplinasTurma){                    
                    Disciplina disciplina = Collection.FindDisciplina(disciplinaTurma.IdDisciplina);
                    if(disciplina != null) { 
                        ViewModelDisciplina vmDisc = new ViewModelDisciplina() { IdDisciplinaTurma = disciplinaTurma.IdDisciplinaTurma, Nome = disciplina.Nome};
                        disciplinas.Add(vmDisc);
                    }
                }
            }
            ViewBag.DisciplinasList = new SelectList(disciplinas, "IdDisciplinaTurma", "Nome");
            return View();
        }
        public ActionResult Create() {
            ViewBag.turmas = Collection.TurmaList();
            ViewBag.InstituicaoList = Collection.InstituicaoList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(ViewModelDisciplina vmDisciplina){
            Disciplina disciplina = vmDisciplina.Disciplina;
            disciplina.IdMatriz = (int)Session["IdMatriz"];
            Collection.CreateDisciplina(disciplina);
        
            string[] idTurmas = vmDisciplina.idTurmas.Split(';');
            foreach (string t in idTurmas){
                DisciplinaTurma dt = new DisciplinaTurma(){ IdDisciplina = disciplina.IdDisciplina, IdTurma = int.Parse(t) };
                Collection.CreateDisciplinaTurma(dt);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id){
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Disciplina disciplina = Collection.FindDisciplina(id);            
            if (disciplina == null)
                return HttpNotFound();

            ViewModelDisciplina viewModelDisciplina = new ViewModelDisciplina();
            viewModelDisciplina.Disciplina = disciplina;

            List<DisciplinaTurma> aux = Collection.DisciplinaTurmaList().Where(dt => dt.IdDisciplina == viewModelDisciplina.IdDisciplina).ToList();
            foreach (var discTurm in aux)
                viewModelDisciplina.Turmas.Add(Collection.FindTurma(discTurm.IdTurma));
            viewModelDisciplina.EncherTurmas();

            ViewBag.turmas = Collection.TurmaList();
            ViewBag.InstituicaoList = Collection.InstituicaoList();
            
            return View(viewModelDisciplina);
        }

        [HttpPost]
        public ActionResult Edit(ViewModelDisciplina vmDisciplina){            
            Disciplina disciplina = Collection.EditDisciplina(vmDisciplina.Disciplina);
            if(disciplina == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            string[] idTurmas = vmDisciplina.idTurmas != null ? vmDisciplina.idTurmas.Split(';') : new string[0];
                foreach (var id in idTurmas)
                    vmDisciplina.Turmas.Add(Collection.FindTurma(int.Parse(id)));
 
                List<DisciplinaTurma> dts = Collection.DisciplinaTurmaList().Where(dt => dt.IdDisciplina == vmDisciplina.IdDisciplina).ToList();
                List<Turma> turmasBanco = new List<Turma>();
                foreach (var aux in dts)
                    turmasBanco.Add(Collection.FindTurma(aux.IdTurma));

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
                        DisciplinaTurma dt = new DisciplinaTurma() {IdDisciplina = disciplina.IdDisciplina, IdTurma = vmDisciplina.Turmas[i].IdTurma};
                        Collection.CreateDisciplinaTurma(dt);
                    }
                }
                foreach (var item in turmasBanco){
                    DisciplinaTurma dt = Collection.DisciplinaTurmaList().Where(aux => aux.IdDisciplina == vmDisciplina.IdDisciplina && aux.IdTurma == item.IdTurma).Single();
                    if(dt != null)
                        Collection.DeleteDisciplinaTurma(dt.IdDisciplinaTurma);
                }            
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id){
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Disciplina disciplina = Collection.FindDisciplina(id);
            if (disciplina == null)
                return HttpNotFound();

            ViewModelDisciplina viewModelDisciplina = new ViewModelDisciplina();
            viewModelDisciplina.Disciplina = disciplina;

            List<DisciplinaTurma> aux = Collection.DisciplinaTurmaList().Where(dt => dt.IdDisciplina == viewModelDisciplina.IdDisciplina).ToList();
            foreach (var discTurm in aux)
                viewModelDisciplina.Turmas.Add(Collection.FindTurma(discTurm.IdTurma));
            viewModelDisciplina.EncherTurmas();

            ViewBag.turmas = Collection.TurmaList();
            ViewBag.InstituicaoList = Collection.InstituicaoList();
            
            return View(viewModelDisciplina);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id){
            Disciplina disciplina = Collection.FindDisciplina(id);
            if (disciplina == null)            
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            List<DisciplinaTurma> disciplinaTurmas = Collection.DisciplinaTurmaList().Where(dt => dt.IdDisciplina == id).ToList();
            foreach (var dt in disciplinaTurmas){
                Collection.DeleteDisciplinaTurma(dt.IdDisciplinaTurma);
            }            
            Collection.DeleteDisciplina(disciplina.IdDisciplina);
            
            return RedirectToAction("Index");
        }
    }
}