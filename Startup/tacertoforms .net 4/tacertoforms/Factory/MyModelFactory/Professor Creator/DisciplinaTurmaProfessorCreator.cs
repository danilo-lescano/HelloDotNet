using System.Collections.Generic;
using System.Linq;
using System.Web;

using TaCertoForms.Contexts;
using TaCertoForms.Models;

namespace TaCertoForms.Factory {
    public class DisciplinaTurmaProfessorCreator : BaseCreator, IFactoryDisciplinaTurma {
        public DisciplinaTurmaProfessorCreator(HttpSessionStateBase session) : base(session) { }

        public DisciplinaTurma CreateDisciplinaTurma(DisciplinaTurma disciplinaTurma) {
            throw new System.NotImplementedException();
        }

        public bool DeleteDisciplinaTurma(int? id) {
            throw new System.NotImplementedException();
        }

        public List<DisciplinaTurma> DisciplinaTurmaList() {
            Context db = new Context();

            Pessoa pessoa = db.Pessoa.Find(IdPessoa);
            if (pessoa == null) return null;

            List<int> idAuxList = new List<int>();
            List<TurmaDisciplinaAutor> turmaDisciplinaAutorList = db.TurmaDisciplinaAutor.Where(tda => tda.IdAutor == pessoa.IdPessoa).ToList();
            if (turmaDisciplinaAutorList == null || turmaDisciplinaAutorList.Count == 0) return null;
            foreach (var tda in turmaDisciplinaAutorList) idAuxList.Add(tda.IdDisciplinaTurma);

            List<DisciplinaTurma> disciplinaTurmaList = db.DisciplinaTurma.Where(dt => idAuxList.Contains(dt.IdDisciplinaTurma)).ToList();
            if (disciplinaTurmaList == null || disciplinaTurmaList.Count == 0) return null;

            db.Dispose();
            return disciplinaTurmaList;
        }

        public DisciplinaTurma EditDisciplinaTurma(DisciplinaTurma disciplinaTurma) {
            throw new System.NotImplementedException();
        }

        public DisciplinaTurma FindDisciplinaTurma(int? id) {
            Context db = new Context();

            Pessoa pessoa = db.Pessoa.Find(IdPessoa);
            DisciplinaTurma disciplinaTurma = db.DisciplinaTurma.Find(id);
            if (pessoa == null || disciplinaTurma == null) return null;

            List<int> idAuxList = new List<int>();
            List<TurmaDisciplinaAutor> turmaDisciplinaAutorList = db.TurmaDisciplinaAutor.Where(tda => tda.IdAutor == pessoa.IdPessoa).ToList();
            if (turmaDisciplinaAutorList == null || turmaDisciplinaAutorList.Count == 0) return null;
            foreach (var tda in turmaDisciplinaAutorList) idAuxList.Add(tda.IdDisciplinaTurma);

            db.Dispose();
            if (idAuxList.Contains(disciplinaTurma.IdDisciplinaTurma)) return disciplinaTurma;
            return null;
        }
    }
}