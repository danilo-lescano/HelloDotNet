using System.Collections.Generic;
using TaCertoForms.Models;
using TaCertoForms.Contexts;
using System.Linq;

namespace TaCertoForms.Factory{
    public class DisciplinaMatrizCreator : BaseCreator, IFactoryDisciplina{
        public DisciplinaMatrizCreator(int IdMatriz, int IdPessoa) : base(IdMatriz, IdPessoa) { }

        public Disciplina CreateDisciplina(Disciplina disciplina){
            throw new System.NotImplementedException();
        }

        public bool DeleteDisciplina(int? id){
            throw new System.NotImplementedException();
        }

        public List<Disciplina> DisciplinaList(){
            Context db = new Context();
            Pessoa pessoa = db.Pessoa.Find(IdPessoa);
            Instituicao instituicao = db.Instituicao.Find(pessoa.IdInstituicao);
            if(pessoa == null || instituicao == null) return null;
            
            List<Disciplina> disciplinas = db.Disciplina.Where(x => x.IdMatriz == instituicao.IdMatriz).ToList();
            db.Dispose();
            return disciplinas;            
        }

        public Disciplina EditDisciplina(Disciplina disciplina){            
            Context db = new Context();
            Pessoa pessoa = db.Pessoa.Find(IdPessoa);
            Instituicao instituicao = db.Instituicao.Find(pessoa.IdInstituicao);
            if (pessoa == null || instituicao == null || db.Disciplina.Find(disciplina.IdDisciplina) == null) return null;
            db.Entry(disciplina).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            db.Dispose();
            return disciplina;            
        }

        public Disciplina FindDisciplina(int? id){
            Context db = new Context();
            Pessoa pessoa = db.Pessoa.Find(IdPessoa);
            Instituicao instituicao = db.Instituicao.Find(pessoa.IdInstituicao);
            if (pessoa == null || instituicao == null){
                //Disciplina disciplina = db.Disciplina.Where(x => x.IdDisciplina == id && x.IdMatriz == instituicao.IdMatriz);
                //return disciplina != null ? disciplina : null;
            }
            return null;
        }
    }
}