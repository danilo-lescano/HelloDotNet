using System.Collections.Generic;
using System.Linq;
using System.Web;

using TaCertoForms.Contexts;
using TaCertoForms.Models;

namespace TaCertoForms.Factory {
    public class TurmaProfessorCreator : BaseCreator, IFactoryTurma {
        public TurmaProfessorCreator(HttpSessionStateBase session) : base(session) { }

        public Turma FindTurma(int? id) {
            Context db = new Context();
            List<int> idAuxList;

            Pessoa pessoa = db.Pessoa.Find(IdPessoa);
            Turma turma = db.Turma.Find(id);
            if(pessoa == null || turma == null) return null;

            List<TurmaDisciplinaAutor> turmaDisciplinaAutorList = db.TurmaDisciplinaAutor.Where(tda => tda.IdAutor == pessoa.IdPessoa).ToList();
            if(turmaDisciplinaAutorList == null || turmaDisciplinaAutorList.Count == 0) return null;
            idAuxList = new List<int>();
            foreach(var tda in turmaDisciplinaAutorList) idAuxList.Add(tda.IdDisciplinaTurma);

            List<DisciplinaTurma> disciplinaTurmaList = db.DisciplinaTurma.Where(dt => idAuxList.Contains(dt.IdDisciplinaTurma)).ToList();
            if(disciplinaTurmaList == null || disciplinaTurmaList.Count == 0) return null;
            idAuxList = new List<int>();
            foreach(var dt in disciplinaTurmaList) idAuxList.Add(dt.IdTurma);

            db.Dispose();
            if(idAuxList.Contains(turma.IdTurma)) return turma;
            return null;
        }

        public List<Turma> TurmaList() {
            Context db = new Context();
            List<int> idAuxList;

            Pessoa pessoa = db.Pessoa.Find(IdPessoa);
            if(pessoa == null) return null;

            List<TurmaDisciplinaAutor> turmaDisciplinaAutorList = db.TurmaDisciplinaAutor.Where(tda => tda.IdAutor == IdPessoa).ToList();
            if(turmaDisciplinaAutorList == null || turmaDisciplinaAutorList.Count == 0) return null;
            idAuxList = new List<int>();
            foreach(var tda in turmaDisciplinaAutorList) idAuxList.Add(tda.IdDisciplinaTurma);

            List<DisciplinaTurma> disciplinaTurmaList = db.DisciplinaTurma.Where(dt  => idAuxList.Contains(dt.IdDisciplinaTurma)).ToList();
            if(disciplinaTurmaList == null || disciplinaTurmaList.Count == 0) return null;
            idAuxList = new List<int>();
            foreach(var dt in disciplinaTurmaList) idAuxList.Add(dt.IdTurma);

            List<Turma> turmas = db.Turma.Where(a => idAuxList.Contains(a.IdTurma)).ToList();
            if(turmas == null || turmas.Count == 0) return null;

            db.Dispose();
            return turmas;
        }

        public Turma CreateTurma(Turma turma) {
            throw new System.NotImplementedException();
        }

        public Turma EditTurma(Turma turma) {
            throw new System.NotImplementedException();
        }

        public bool DeleteTurma(int? id) {
            throw new System.NotImplementedException();
        }
    }
}