using System.Collections.Generic;
using TaCertoForms.Models;
using TaCertoForms.Contexts;

namespace TaCertoForms.Factory{
    public class PessoaMatrizCreator : BaseCreator, IPessoa{
        private Context db = new Context();

        public PessoaMatrizCreator(int IdMatriz, int IdPessoa) : base(IdMatriz,IdPessoa) {}

        public Pessoa FindPessoa(int? id){
            return null;
        }

        public List<Pessoa> PessoaList(){
            return null;
        }
    }
}