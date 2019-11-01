using System.Linq;
using System.Collections.Generic;
using TaCertoForms.Models;
using TaCertoForms.Contexts;

namespace TaCertoForms.Factory{
    public class PessoaProfessorCreator : BaseCreator, IFactoryPessoa{
        public PessoaProfessorCreator(int IdMatriz, int IdPessoa) : base(IdMatriz,IdPessoa) {}

        public Pessoa CreatePessoa(Pessoa pessoa)
        {
            throw new System.NotImplementedException();
        }

        public bool DeletePessoa(int? id)
        {
            throw new System.NotImplementedException();
        }

        public Pessoa EditPessoa(Pessoa pessoa)
        {
            throw new System.NotImplementedException();
        }

        public Pessoa FindPessoa(int? id)
        {
            throw new System.NotImplementedException();
        }

        public List<Pessoa> PessoaList()
        {
            throw new System.NotImplementedException();
        }
    }
}