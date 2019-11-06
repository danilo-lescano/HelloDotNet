using System.Collections.Generic;
using System.Web;

using TaCertoForms.Models;

namespace TaCertoForms.Factory {
    //CLASSE EnderecoProfessorCreator - Responsavel por pegar no banco de dados apenas as endereços relacionadas a uma determinada matriz
    public class EnderecoProfessorCreator : BaseCreator, IFactoryEndereco {
        public EnderecoProfessorCreator(HttpSessionStateBase session) : base(session) { }

        public Endereco CreateEndereco(Endereco endereco) {
            throw new System.NotImplementedException();
        }

        public bool DeleteEndereco(int? id) {
            throw new System.NotImplementedException();
        }

        public Endereco EditEndereco(Endereco endereco) {
            throw new System.NotImplementedException();
        }

        public List<Endereco> EnderecoList() {
            throw new System.NotImplementedException();
        }

        public Endereco FindEndereco(int? id) {
            throw new System.NotImplementedException();
        }
    }
}