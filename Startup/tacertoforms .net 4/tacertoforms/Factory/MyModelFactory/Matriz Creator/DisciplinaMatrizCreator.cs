using System.Collections.Generic;
using TaCertoForms.Models;
using TaCertoForms.Contexts;
using System.Linq;

namespace TaCertoForms.Factory{
    public class DisciplinaMatrizCreator : BaseCreator, IFactoryDisciplina{
        public DisciplinaMatrizCreator(int IdMatriz, int IdPessoa) : base(IdMatriz, IdPessoa) { }

        public Disciplina FindDisciplina(int? id){
            if(id == null) return false;
            Context db = new Context();
            Disciplina disciplina = db.Disciplina.Where(d => d.IdMatriz = IdMatriz && d.IdDisciplina == id);
            db.Dispose();
            return disciplina;   
        }

        public List<Disciplina> DisciplinaList(){
            Context db = new Context();
            List<Disciplina> disciplinas = db.Disciplina.Where(d => d.IdMatriz == IdMatriz).ToList();
            db.Dispose();
            return disciplinas;
        }

        public Disciplina CreateDisciplina(Disciplina disciplina){
            Context db = new Context();
            disciplina.IdMatriz = IdMatriz;
            db.Disciplina.Add(db);
            db.SaveChanges();
            db.Dispose();
            return disciplina;
        }
        
        public Disciplina EditDisciplina(Disciplina disciplina){
            Context db = new Context();
            if(disciplina.IdMatriz != IdMatriz) return null;
            db.Entry(disciplina).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            db.Dispose();
            return disciplina;   
        }

        public bool DeleteDisciplina(int? id){
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