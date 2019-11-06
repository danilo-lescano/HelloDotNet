using System.Collections.Generic;
using System.Linq;
using System.Web;

using TaCertoForms.Contexts;
using TaCertoForms.Models;

namespace TaCertoForms.Factory {
    public class TurmaAlunoProfessorCreator : BaseCreator, IFactoryTurmaAluno {
        public TurmaAlunoProfessorCreator(HttpSessionStateBase session) : base(session) { }

        public TurmaAluno FindTurmaAluno(int? id) {
            if(id == null) return null;
            Context db = new Context();
            List<int> idAuxList;

            List<TurmaDisciplinaAutor> turmaDisciplinaAutorList = db.TurmaDisciplinaAutor.Where(tda => tda.IdAutor == IdPessoa).ToList();
            if(turmaDisciplinaAutorList == null || turmaDisciplinaAutorList.Count == 0) return null;
            idAuxList = new List<int>();
            foreach(var tda in turmaDisciplinaAutorList) idAuxList.Add(tda.IdDisciplinaTurma);

            List<DisciplinaTurma> disciplinaTurmaList = db.DisciplinaTurma.Where(dt => idAuxList.Contains(dt.IdDisciplinaTurma)).ToList();
            if(disciplinaTurmaList == null || disciplinaTurmaList.Count == 0) return null;
            idAuxList = new List<int>();
            foreach(var dt in disciplinaTurmaList) idAuxList.Add(dt.IdTurma);

            Turma turma = db.Turma.Where(t => t.IdTurma == id && idAuxList.Contains(t.IdTurma)).FirstOrDefault();

            TurmaAluno turmaAluno = db.TurmaAluno.Where(ta => ta.IdTurmaAluno == id && ta.IdTurma == turma.IdTurma).FirstOrDefault();

            return turmaAluno;
        }

        public List<TurmaAluno> TurmaAlunoList() {
            Context db = new Context();
            List<int> idAuxList;

            List<TurmaDisciplinaAutor> turmaDisciplinaAutorList = db.TurmaDisciplinaAutor.Where(tda => tda.IdAutor == IdPessoa).ToList();
            if(turmaDisciplinaAutorList == null || turmaDisciplinaAutorList.Count == 0) return null;
            idAuxList = new List<int>();
            foreach(var tda in turmaDisciplinaAutorList) idAuxList.Add(tda.IdDisciplinaTurma);

            List<DisciplinaTurma> disciplinaTurmaList = db.DisciplinaTurma.Where(dt => idAuxList.Contains(dt.IdDisciplinaTurma)).ToList();
            if(disciplinaTurmaList == null || disciplinaTurmaList.Count == 0) return null;
            idAuxList = new List<int>();
            foreach(var dt in disciplinaTurmaList) idAuxList.Add(dt.IdTurma);

            List<TurmaAluno> turmaAlunoList = db.TurmaAluno.Where(ta => idAuxList.Contains(ta.IdTurma)).ToList();

            return turmaAlunoList;
        }

        public TurmaAluno CreateTurmaAluno(TurmaAluno turmaAluno) {
            throw new System.NotImplementedException();
        }

        public TurmaAluno EditTurmaAluno(TurmaAluno turmaAluno) {
            throw new System.NotImplementedException();
        }

        public bool DeleteTurmaAluno(int? id) {
            throw new System.NotImplementedException();
        }
    }
}