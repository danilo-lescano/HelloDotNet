using System.Collections.Generic;
using TaCertoForms.Models;
using TaCertoForms.Contexts;

namespace TaCertoForms.Factory{
    public class PessoaMatrizCreator : IPessoa{
        private Context db = new Context();

        public Pessoa FindPessoa(int? id){
            return null;
        }

        public List<Pessoa> PessoaList(){
            return null;
        }
    }
}