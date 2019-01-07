using System;
using System.Collections.Generic;
using TaCertoForms.Models;
namespace TaCertoForms.Models
{
    public class DesafioDeFaseManager{
        public Dictionary<string, Object> Session { get; set; }
        private DesafioDeFaseFactory desafioFactory = new DesafioDeFaseFactory();

        public List<DesafioDeFase> CarregaDesafios(int idFase){
            List<DesafioDeFase> listaDeDesafios = desafioFactory.GetDesafiosByFaseId(idFase);
            return listaDeDesafios;
        }

    }
}