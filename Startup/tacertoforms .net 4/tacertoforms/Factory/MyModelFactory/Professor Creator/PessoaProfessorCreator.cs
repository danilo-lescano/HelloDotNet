using System.Linq;
using System.Collections.Generic;
using TaCertoForms.Models;
using TaCertoForms.Contexts;

namespace TaCertoForms.Factory{
    public class PessoaProfessorCreator : BaseCreator, IFactoryPessoa{
        public PessoaProfessorCreator(int IdMatriz, int IdPessoa) : base(IdMatriz,IdPessoa) {}

        public Pessoa FindPessoa(int? id){
            throw new System.NotImplementedException();
        }

        public List<Pessoa> PessoaList(){
            Context db = new Context();
            List<TurmaAluno> turmaAlunos = new List<TurmaAluno>();
            List<Pessoa> alunos = new List<Pessoa>();
            List<TurmaDisciplinaAutor> tda_aux = db.TurmaDisciplinaAutor.Where(tda => tda.IdAutor == IdPessoa).ToList();
            foreach (var tda in tda_aux){
                DisciplinaTurma dt = db.DisciplinaTurma.Find(tda.IdDisciplinaTurma);
                Turma t = db.Turma.Find(dt.IdTurma);
                List<TurmaAluno> ta_aux = db.TurmaAluno.Where(ta => ta.IdTurma == t.IdTurma && !turmaAlunos.Contains(ta)).ToList();
                turmaAlunos = turmaAlunos.Concat(ta_aux).ToList();
            }
            foreach (var ta in turmaAlunos){
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
            throw new System.NotImplementedException();
        }
        
        public bool DeletePessoa(int? id){
            throw new System.NotImplementedException();
        }
    }
}