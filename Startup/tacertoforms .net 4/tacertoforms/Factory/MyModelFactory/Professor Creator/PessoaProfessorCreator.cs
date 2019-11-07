using System.Collections.Generic;
using System.Linq;
using System.Web;

using TaCertoForms.Contexts;
using TaCertoForms.Models;

namespace TaCertoForms.Factory {
    public class PessoaProfessorCreator : BaseCreator, IFactoryPessoa {
        public PessoaProfessorCreator(HttpSessionStateBase session) : base(session) {}

        public Pessoa FindPessoa(int? id) {
            if(id == null) return null;
            Context db = new Context();
            List<int> idAuxList;

            Pessoa pessoa = db.Pessoa.Find(id);
            if (id == IdPessoa) return pessoa;

            List<TurmaDisciplinaAutor> turmaDisciplinaAutorList = db.TurmaDisciplinaAutor.Where(tda => tda.IdAutor == IdPessoa).ToList();
            if(turmaDisciplinaAutorList == null || turmaDisciplinaAutorList.Count == 0) return null;
            idAuxList = new List<int>();
            foreach(var item in turmaDisciplinaAutorList) idAuxList.Add(item.IdDisciplinaTurma);

            List<DisciplinaTurma> disciplinaTurmaList = db.DisciplinaTurma.Where(dt => idAuxList.Contains(dt.IdDisciplinaTurma)).ToList();
            if(disciplinaTurmaList == null || disciplinaTurmaList.Count == 0) return null;
            idAuxList = new List<int>();
            foreach(var item in disciplinaTurmaList) idAuxList.Add(item.IdTurma);

            List<TurmaAluno> turmaAlunoList = db.TurmaAluno.Where(ta => idAuxList.Contains(ta.IdTurma) && ta.IdPessoa == id).ToList();
            if(turmaAlunoList == null || turmaAlunoList.Count == 0) return null;
            
            return pessoa;
        }

        public List<Pessoa> PessoaList() {
            Context db = new Context();
            List<TurmaAluno> turmaAlunos = new List<TurmaAluno>();
            List<Pessoa> alunos = new List<Pessoa>();
            List<TurmaDisciplinaAutor> tda_aux = db.TurmaDisciplinaAutor.Where(tda => tda.IdAutor == IdPessoa).ToList();
            foreach(var tda in tda_aux) {
                DisciplinaTurma dt = db.DisciplinaTurma.Find(tda.IdDisciplinaTurma);
                Turma t = db.Turma.Find(dt.IdTurma);
                List<TurmaAluno> ta_aux = db.TurmaAluno.Where(ta => ta.IdTurma == t.IdTurma && !turmaAlunos.Contains(ta)).ToList();
                turmaAlunos = turmaAlunos.Concat(ta_aux).ToList();
            }
            foreach(var ta in turmaAlunos) {
                Pessoa p = db.Pessoa.Find(ta.IdPessoa);
                if(p != null)
                    alunos.Add(p);
            }
            db.Dispose();
            return alunos;
        }

        public Pessoa CreatePessoa(Pessoa pessoa){
            throw new System.NotImplementedException();
        }

        public Pessoa EditPessoa(Pessoa pessoa){
            Context db = new Context();

            Pessoa pessoa_aux = db.Pessoa.Find(pessoa.IdPessoa);
            if (pessoa_aux == null) return null;
            if (pessoa.IdPessoa != IdPessoa) return null;

            pessoa.Perfil = Perfil.Autor;
            db.Dispose();
            db = new Context();
            db.Entry(pessoa).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            db.Dispose();
            return pessoa;            
        }

        public bool DeletePessoa(int? id){
            throw new System.NotImplementedException();
        }
    }
}