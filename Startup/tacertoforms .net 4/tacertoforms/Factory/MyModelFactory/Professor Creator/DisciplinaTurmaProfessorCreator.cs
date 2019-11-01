using System.Collections.Generic;
using TaCertoForms.Models;
using TaCertoForms.Contexts;
using System.Linq;

namespace TaCertoForms.Factory{
    public class DisciplinaTurmaProfessorCreator : BaseCreator, IFactoryDisciplinaTurma{
        public DisciplinaTurmaProfessorCreator(int IdMatriz, int IdPessoa) : base(IdMatriz, IdPessoa) { }

        public DisciplinaTurma CreateDisciplinaTurma(DisciplinaTurma disciplinaTurma){
            throw new System.NotImplementedException();
        }

        public bool DeleteDisciplinaTurma(int? id){
            throw new System.NotImplementedException();
        }

        public List<DisciplinaTurma> DisciplinaTurmaList(){
            throw new System.NotImplementedException();
        }

        public DisciplinaTurma EditDisciplinaTurma(DisciplinaTurma disciplinaTurma){
            throw new System.NotImplementedException();
        }

        public DisciplinaTurma FindDisciplinaTurma(int? id){
            throw new System.NotImplementedException();
        }
    }
}