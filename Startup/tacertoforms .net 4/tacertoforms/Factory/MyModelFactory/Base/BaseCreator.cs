using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using TaCertoForms.Models;

namespace TaCertoForms.Factory{
    public class BaseCreator{
        protected Context db = new Context();
        protected int IdMatriz { get; set; }
        protected int IdPessoa { get; set; }

        public BaseCreator(int IdMatriz, int IdPessoa){
            this.IdMatriz = IdMatriz;
            this.IdPessoa = IdPessoa;
        }
    }
}