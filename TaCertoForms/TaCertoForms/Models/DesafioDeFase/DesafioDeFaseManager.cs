using System;
using System.Collections.Generic;
using TaCertoForms.Models;
using Util;

namespace TaCertoForms.Models{
    public class DesafioDeFaseManager{
        public Session Session { get; set; }
        private DesafioDeFaseFactory desafioFactory = new DesafioDeFaseFactory();

        public List<IDesafioDeFase> CarregaDesafios(int idFase){
            List<IDesafioDeFase> listaDeDesafios = desafioFactory.GetDesafiosByFaseId(idFase);
            return listaDeDesafios;
        }

    }
}