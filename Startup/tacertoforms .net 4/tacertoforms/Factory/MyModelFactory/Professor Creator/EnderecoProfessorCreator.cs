using System.Linq;
using System.Collections.Generic;
using TaCertoForms.Models;
using TaCertoForms.Contexts;

namespace TaCertoForms.Factory{
    //CLASSE EnderecoProfessorCreator - Responsavel por pegar no banco de dados apenas as endereços relacionadas a uma determinada matriz
    public class EnderecoProfessorCreator : BaseCreator, IFactoryEndereco{
        public EnderecoProfessorCreator(int IdMatriz, int IdPessoa) : base(IdMatriz,IdPessoa) {}

        public Endereco CreateEndereco(Endereco endereco)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteEndereco(int? id)
        {
            throw new System.NotImplementedException();
        }

        public Endereco EditEndereco(Endereco endereco)
        {
            throw new System.NotImplementedException();
        }

        public List<Endereco> EnderecoList()
        {
            throw new System.NotImplementedException();
        }

        public Endereco FindEndereco(int? id)
        {
            throw new System.NotImplementedException();
        }
    }
}