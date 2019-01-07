using System;
using System.Collections.Generic;
using TaCertoForms.Models;
namespace TaCertoForms.Models{
    public class FaseManager{
        public Dictionary<string, Object> Session { get; set; }
        private FaseFactory faseFactory = new FaseFactory();
        public List<Fase> CarregaFases(){
            List<Fase> listaDeFases = null;
            Usuario usuario = null;
            if(Session.ContainsKey("usuario")){
                usuario = (Usuario)Session["usuario"];
                listaDeFases = faseFactory.GetFaseByUserId(usuario.Id);
            }
            return listaDeFases;
        }

        public void SalvarFaseNormal(Fase fase){

            Console.WriteLine("chamar o factory para salvar a fase");
        }
    }
}