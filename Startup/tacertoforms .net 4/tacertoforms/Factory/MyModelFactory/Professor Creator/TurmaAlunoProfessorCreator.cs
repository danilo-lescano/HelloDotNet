using System.Linq;
using System.Collections.Generic;
using TaCertoForms.Models;
using TaCertoForms.Contexts;

namespace TaCertoForms.Factory{
    public class TurmaAlunoProfessorCreator : BaseCreator, IFactoryTurmaAluno{

        public TurmaAlunoProfessorCreator(int IdMatriz, int IdPessoa) : base(IdMatriz, IdPessoa) { }

        public TurmaAluno FindTurmaAluno(int? id){
            throw new System.NotImplementedException();
        }

        public List<TurmaAluno> TurmaAlunoList(){
            throw new System.NotImplementedException();
        }

        public TurmaAluno CreateTurmaAluno(TurmaAluno turmaAluno){
            throw new System.NotImplementedException();
        }

        public TurmaAluno EditTurmaAluno(TurmaAluno turmaAluno){
            throw new System.NotImplementedException();
        }

        public bool DeleteTurmaAluno(int? id){
            throw new System.NotImplementedException();
        }
    }
}