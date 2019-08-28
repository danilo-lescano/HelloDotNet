using System;
using System.Collections.Generic;
using TaCertoForms.Models;
using Util;

namespace TaCertoForms.Models{
    public class FaseManager{
        public Session Session { get; set; }
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

        public bool SalvarFaseNormal(Fase fase){

            Console.WriteLine("chamar o factory para salvar a fase");
        
            return true;
        }
        public bool SalvarFaseLacuna(Fase fase){
            for(int i = 0; i < 100; i++)
                Console.WriteLine(fase.Chave + " x ");// + fase.desafiosLacuna[0].FraseXlacuna[0].conteudo);
            Console.WriteLine("chamar o factory para salvar a fase");
        
            return true;
        }

        public int getTipoFaseById(int idFase){

            return faseFactory.getTipoFaseById(idFase);
        }

        public Fase getJsonFaseById(int idFase){

            return faseFactory.getJsonFaseById(idFase);
        }
    }
}