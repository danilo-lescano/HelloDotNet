using System.Collections.Generic;
using TaCertoForms.Models;
using TaCertoForms.Contexts;
using System.Linq;
namespace TaCertoForms.Factory{
    public class DisciplinaTurmaMatrizCreator : BaseCreator, IFactoryDisciplinaTurma{
        public DisciplinaTurmaMatrizCreator(int IdMatriz, int IdPessoa) : base(IdMatriz, IdPessoa) { }

        public DisciplinaTurma CreateDisciplinaTurma(DisciplinaTurma disciplinaTurma){
            throw new System.NotImplementedException();
        }

        public bool DeleteDisciplinaTurma(int? id){
            throw new System.NotImplementedException();
        }

        public List<DisciplinaTurma> DisciplinaTurmaList(){
            Context db = new Context();
            Pessoa pessoa = db.Pessoa.Find(IdPessoa);
            Instituicao instituicao = db.Instituicao.Find(pessoa.IdInstituicao);
            if(pessoa == null || instituicao == null) return null;
            
            List<DisciplinaTurma> disciplinaTurmas = db.DisciplinaTurma.Where(x => x.IdMatriz == instituicao.IdMatriz).ToList();
            db.Dispose();
            return disciplinaTurmas;            
        }

        public DisciplinaTurma EditDisciplinaTurma(DisciplinaTurma disciplinaTurma){            
            Context db = new Context();
            Pessoa pessoa = db.Pessoa.Find(IdPessoa);
            Instituicao instituicao = db.Instituicao.Find(pessoa.IdInstituicao);
            if (pessoa == null || instituicao == null || db.DisciplinaTurma.Find(disciplinaTurma.IdDisciplinaTurma) == null) return null;
            db.Entry(disciplinaTurma).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            db.Dispose();
            return disciplinaTurma;            
        }

        public DisciplinaTurma FindDisciplinaTurma(int? id){
            Context db = new Context();
            Pessoa pessoa = db.Pessoa.Find(IdPessoa);
            Instituicao instituicao = db.Instituicao.Find(pessoa.IdInstituicao);
            if (pessoa == null || instituicao == null){
                //DisciplinaTurma disciplinaTurma = db.DisciplinaTurma.Where(x => x.IdDisciplinaTurma == id && x.IdMatriz == instituicao.IdMatriz);
                //return disciplinaTurma != null ? disciplinaTurma : null;
            }
            return null;
        }
    }
}