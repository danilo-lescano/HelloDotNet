using System.Collections.Generic;
using TaCertoForms.Models;
using TaCertoForms.Contexts;
using System.Linq;

namespace TaCertoForms.Factory{
    public class DisciplinaProfessorCreator : BaseCreator, IFactoryDisciplina{
        public DisciplinaProfessorCreator(int IdMatriz, int IdPessoa) : base(IdMatriz, IdPessoa) { }

        public Disciplina CreateDisciplina(Disciplina disciplina)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteDisciplina(int? id)
        {
            throw new System.NotImplementedException();
        }

        public List<Disciplina> DisciplinaList()
        {
            throw new System.NotImplementedException();
        }

        public Disciplina EditDisciplina(Disciplina disciplina)
        {
            throw new System.NotImplementedException();
        }

        public Disciplina FindDisciplina(int? id)
        {
            throw new System.NotImplementedException();
        }
    }
}