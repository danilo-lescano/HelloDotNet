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
            Context db = new Context();

            DisciplinaTurma disciplinaTurma_aux = db.DisciplinaTurma.Find(disciplinaTurma.IdDisciplinaTurma);
            if(disciplinaTurma_aux == null) return null;

            if(disciplinaTurma_aux.IdTurma != disciplinaTurma.IdTurma){
                Turma turma_aux = db.Turma.Find(disciplinaTurma_aux.IdTurma);
                if(turma_aux == null) return null;

                Instituicao instituicao_aux = db.Instituicao.Find(turma_aux.IdInstituicao);
                if(instituicao_aux.IdInstituicao != IdMatriz && (instituicao_aux.IdMatriz == null || instituicao_aux.IdMatriz != IdMatriz)) return null;
            }

            if(disciplinaTurma_aux.IdDisciplina != disciplinaTurma.IdDisciplina){
                Disciplina disciplina_aux = db.Disciplina.Find(disciplinaTurma_aux.IdDisciplina);
                if(disciplina_aux == null) return null;
                if(disciplina_aux.IdMatriz != IdMatriz) return null;
            }

            db.Dispose();
            db = new Context();
            db.Entry(disciplinaTurma).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            db.Dispose();

            return disciplinaTurma;
        }

        public bool DeleteDisciplinaTurma(int? id){
            if(id == null) return false;
            Context db = new Context();

            DisciplinaTurma disciplinaTurma = db.DisciplinaTurma.Find(id);
            if(disciplinaTurma == null) return false;

            Turma turma = db.Turma.Find(disciplinaTurma.IdTurma);
            if(turma == null) return false;

            Instituicao instituicao = db.Instituicao.Find(turma.IdInstituicao);
            if(instituicao == null || (instituicao.IdInstituicao != IdMatriz && instituicao.IdMatriz != IdMatriz)) return false;

            db.DisciplinaTurma.Remove(disciplinaTurma);
            db.SaveChanges();
            db.Dispose();
            return true;
        }
    }
}