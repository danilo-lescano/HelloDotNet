using System.Collections.Generic;
using TaCertoForms.Models;
using TaCertoForms.Contexts;
using System.Linq;

namespace TaCertoForms.Factory{
    public class DisciplinaTurmaMatrizCreator : BaseCreator, IFactoryDisciplinaTurma{
        public DisciplinaTurmaMatrizCreator(int IdMatriz, int IdPessoa) : base(IdMatriz, IdPessoa) { }

        public DisciplinaTurma FindDisciplinaTurma(int? id){
            if (id == null) return null;
            Context db = new Context();

            DisciplinaTurma disciplinaTurma = db.DisciplinaTurma.Find(id);
            if(disciplinaTurma == null) return null;

            Turma turma = db.Turma.Find(disciplinaTurma.IdTurma);
            if(turma == null) return null;

            Instituicao instituicao = db.Instituicao.Find(turma.IdInstituicao);
            if(instituicao == null) return null;

            if (instituicao.IdInstituicao != IdMatriz && (instituicao.IdMatriz == null || instituicao.IdMatriz != IdMatriz))
                return null;

            db.Dispose();
            return disciplinaTurma;
        }

        public List<DisciplinaTurma> DisciplinaTurmaList(){
            Context db = new Context();
            Pessoa pessoa = db.Pessoa.Find(IdPessoa);
            Instituicao instituicao = db.Instituicao.Find(pessoa.IdInstituicao);
            if(pessoa == null || instituicao == null) return null;

            List<DisciplinaTurma> disciplinaTurmas = new List<DisciplinaTurma>();//db.DisciplinaTurma.Where(x => x.IdMatriz == instituicao.IdMatriz).ToList();
            db.Dispose();
            return disciplinaTurmas;
        }

        public DisciplinaTurma CreateDisciplinaTurma(DisciplinaTurma disciplinaTurma){
            throw new System.NotImplementedException();
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

        public bool DeleteDisciplinaTurma(int? id){
            throw new System.NotImplementedException();
        }
    }
}