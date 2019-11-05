using System.Web;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using TaCertoForms.Models;

namespace TaCertoForms.Factory{
    public class BaseCreator{
        protected int IdMatriz { get; set; }
        protected int IdPessoa { get; set; }

        public BaseCreator(HttpSessionStateBase session){
            this.IdMatriz = (int)session["IdMatriz"];
            this.IdPessoa = (int)session["IdPessoa"];
        }
    }
}