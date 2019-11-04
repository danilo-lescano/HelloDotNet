using System.Linq;
using System.Collections.Generic;
using TaCertoForms.Models;
using TaCertoForms.Contexts;

namespace TaCertoForms.Factory{
    public class TurmaProfessorCreator : BaseCreator, IFactoryTurma{
        public TurmaProfessorCreator(int IdMatriz, int IdPessoa) : base(IdMatriz, IdPessoa) { }

        public Turma CreateTurma(Turma turma){
            throw new System.NotImplementedException();
        }

        public bool DeleteTurma(int? id){
            throw new System.NotImplementedException();
        }

        public Turma EditTurma(Turma turma){
            throw new System.NotImplementedException();
        }

        public Turma FindTurma(int? id){
            throw new System.NotImplementedException();
        }

        public List<Turma> TurmaList(){
            throw new System.NotImplementedException();
        }
    }
}