using System.Collections.Generic;
using System.Linq;
using System.Web;

using TaCertoForms.Contexts;
using TaCertoForms.Models;

namespace TaCertoForms.Factory {
    public class DisciplinaMatrizCreator : BaseCreator, IFactoryDisciplina {
        public DisciplinaMatrizCreator(HttpSessionStateBase session) : base(session) { }

        public Disciplina FindDisciplina(int? id) {
            if(id == null) return null;
            Context db = new Context();
            Disciplina disciplina = db.Disciplina.Where(d => d.IdDisciplina == id && d.IdMatriz == IdMatriz).FirstOrDefault();
            db.Dispose();
            return disciplina;   
        }

        public List<Disciplina> DisciplinaList() {
            Context db = new Context();
            List<Disciplina> disciplinas = db.Disciplina.Where(d => d.IdMatriz == IdMatriz).ToList();
            db.Dispose();
            return disciplinas;
        }

        public Disciplina CreateDisciplina(Disciplina disciplina) {
            Context db = new Context();
            disciplina.IdMatriz = IdMatriz;
            db.Disciplina.Add(disciplina);
            db.SaveChanges();
            db.Dispose();
            return disciplina;
        }
        
        public Disciplina EditDisciplina(Disciplina disciplina) {
            Context db = new Context();

            Disciplina disciplina_aux = db.Disciplina.Find(disciplina.IdDisciplina);
            if(disciplina_aux == null || disciplina_aux.IdMatriz != IdMatriz) return null;

            disciplina.IdMatriz = IdMatriz;

            db.Dispose();
            db = new Context();
            db.Entry(disciplina).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            db.Dispose();
            return disciplina;
        }

        public bool DeleteDisciplina(int? id) {
            if(id == null) return false;
            Context db = new Context();
            Disciplina disciplina = db.Disciplina.Find(id);
            if(disciplina == null || disciplina.IdMatriz != IdMatriz)
                return false;
            db.Disciplina.Remove(disciplina);
            db.SaveChanges();
            db.Dispose();
            return true;
        }
    }
}