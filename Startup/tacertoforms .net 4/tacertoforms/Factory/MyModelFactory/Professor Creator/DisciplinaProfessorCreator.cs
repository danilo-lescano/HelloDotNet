using System.Collections.Generic;
using System.Linq;
using System.Web;

using TaCertoForms.Contexts;
using TaCertoForms.Models;

namespace TaCertoForms.Factory {
    public class DisciplinaProfessorCreator : BaseCreator, IFactoryDisciplina {
        public DisciplinaProfessorCreator(HttpSessionStateBase session) : base(session) { }

        public Disciplina CreateDisciplina(Disciplina disciplina) {
            throw new System.NotImplementedException();
        }

        public bool DeleteDisciplina(int? id) {
            throw new System.NotImplementedException();
        }

        public List<Disciplina> DisciplinaList() {
            Context db = new Context();

            Pessoa pessoa = db.Pessoa.Find(IdPessoa);
            if (pessoa == null) return null;

            List<int> idAuxList = new List<int>();
            List<TurmaDisciplinaAutor> turmaDisciplinaAutorList = db.TurmaDisciplinaAutor.Where(tda => tda.IdAutor == pessoa.IdPessoa).ToList();
            if (turmaDisciplinaAutorList == null || turmaDisciplinaAutorList.Count == 0) return null;
            foreach (var tda in turmaDisciplinaAutorList) idAuxList.Add(tda.IdDisciplinaTurma);

            List<DisciplinaTurma> disciplinaTurmaList = db.DisciplinaTurma.Where(dt => idAuxList.Contains(dt.IdDisciplinaTurma)).ToList();
            if (disciplinaTurmaList == null || disciplinaTurmaList.Count == 0) return null;
            idAuxList = new List<int>();
            foreach (var dt in disciplinaTurmaList) idAuxList.Add(dt.IdDisciplina);

            List<Disciplina> disciplinaList = db.Disciplina.Where(a => idAuxList.Contains(a.IdDisciplina)).ToList();
            if (disciplinaList == null || disciplinaList.Count == 0) return null;
            db.Dispose();
            return disciplinaList;
        }

        public Disciplina EditDisciplina(Disciplina disciplina) {
            throw new System.NotImplementedException();
        }

        public Disciplina FindDisciplina(int? id) {
            if (id == null) return null;
            Context db = new Context();

            Pessoa pessoa = db.Pessoa.Find(IdPessoa);
            Disciplina disciplina = db.Disciplina.Find(id);
            if (pessoa == null || disciplina == null) return null;

            List<int> idAuxList = new List<int>();
            List<TurmaDisciplinaAutor> turmaDisciplinaAutorList = db.TurmaDisciplinaAutor.Where(tda => tda.IdAutor == pessoa.IdPessoa).ToList();
            if (turmaDisciplinaAutorList == null || turmaDisciplinaAutorList.Count == 0) return null;
            foreach (var tda in turmaDisciplinaAutorList) idAuxList.Add(tda.IdDisciplinaTurma);

            List<DisciplinaTurma> disciplinaTurmaList = db.DisciplinaTurma.Where(dt => idAuxList.Contains(dt.IdDisciplinaTurma)).ToList();
            if (disciplinaTurmaList == null || disciplinaTurmaList.Count == 0) return null;
            idAuxList = new List<int>();
            foreach (var dt in disciplinaTurmaList) idAuxList.Add(dt.IdDisciplina);

            db.Dispose();
            if (idAuxList.Contains(disciplina.IdDisciplina)) return disciplina; 

            return null; //Caso o professor está tentando buscar uma disciplina que não ministra aula
        }
    }
}