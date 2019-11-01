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
            List<int> idAuxList;

            List<Instituicao> instituicaoList = db.Instituicao.Where(i => i.IdInstituicao == IdMatriz || (i.IdMatriz != null && i.IdMatriz == IdMatriz)).ToList();
            if(instituicaoList == null || instituicaoList.Count == 0) return null;
            idAuxList = new List<int>();
            foreach(var i in instituicaoList) idAuxList.Add(i.IdInstituicao);
            
            List<Turma> turmaList = db.Turma.Where(t => idAuxList.Contains(t.IdInstituicao)).ToList();
            if(turmaList == null || turmaList.Count == 0) return null;
            idAuxList = new List<int>();
            foreach(var t in turmaList) idAuxList.Add(t.IdTurma);

            List<DisciplinaTurma> disciplinaTurmaList = db.DisciplinaTurma.Where(dt => idAuxList.Contains(dt.IdTurma)).ToList();
            if(disciplinaTurmaList == null || disciplinaTurmaList.Count == 0) return null;

            db.Dispose();
            return disciplinaTurmaList;
        }

        public DisciplinaTurma CreateDisciplinaTurma(DisciplinaTurma disciplinaTurma){
            Context db = new Context();

            Turma turma = db.Turma.Find(disciplinaTurma.IdTurma);
            if(turma == null) return null;

            Instituicao instituicao = db.Instituicao.Find(turma.IdInstituicao);
            if(instituicao == null) return null;
            if (instituicao.IdInstituicao != IdMatriz && (instituicao.IdMatriz == null || instituicao.IdMatriz != IdMatriz))
                return null;

            db.DisciplinaTurma.Add(disciplinaTurma);
            db.SaveChanges();
            db.Dispose();
            return disciplinaTurma;
        }

        public DisciplinaTurma EditDisciplinaTurma(DisciplinaTurma disciplinaTurma){
            throw new System.NotImplementedException();
        }

        public bool DeleteDisciplinaTurma(int? id){
            throw new System.NotImplementedException();
        }
    }
}