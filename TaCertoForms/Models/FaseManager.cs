using System;
using System.Collections.Generic;
using TaCertoForms.Models;
using Util;

namespace TaCertoForms.Models{
    public class FaseManager{
        public MultitonSession Session { get; set; }
        private FaseFactory faseFactory = new FaseFactory();
        public List<Fase> CarregaFases(){
            List<Fase> listaDeFases = null;
            int userId;
            if(Session["userId"] != null){
                userId = (int)Session["userId"];
                listaDeFases = faseFactory.GetFaseByUserId(userId);
            }
            return listaDeFases;
        }

        public void SalvarFaseNormal(Fase fase){
            for(int i = 0; i < 100; i++)
                Console.WriteLine(fase.Chave + "   " + fase.desafiosNormal[0].Palavra);
            Console.WriteLine("chamar o factory para salvar a fase");
        }
    }
}