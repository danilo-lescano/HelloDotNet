using System.Collections.Generic;
using TaCertoForms.Models;
using TaCertoForms.Contexts;

namespace TaCertoForms.Factory{
    public class PessoaMatrizCreator : BaseCreator, IFactoryPessoa{
        public PessoaMatrizCreator(int IdMatriz, int IdPessoa) : base(IdMatriz,IdPessoa) {}

        public Pessoa FindPessoa(int? id){
            throw new System.NotImplementedException();
        }

        public List<Pessoa> PessoaList(){
            throw new System.NotImplementedException();
        }
        public Pessoa CreatePessoa(int? id){
            throw new System.NotImplementedException();
        }

        public bool DeletePessoa(int? id){
            throw new System.NotImplementedException();
        }

        public Pessoa EditPessoa(int? id){
            throw new System.NotImplementedException();
        }
    }
}