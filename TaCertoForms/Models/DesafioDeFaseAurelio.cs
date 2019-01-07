using System;
using System.Collections.Generic;
using Util;

namespace TaCertoForms.Models
{
    public class DesafioDeFaseAurelio : DesafioDeFase
    {
        public DesafioDeFaseAurelio(){}
        public DesafioDeFaseAurelio(int id, int faseId, string significado, string dica,
            int index, string palavra, bool eApendice, string apendice,
            string fraseParaCorrecao, int totalSize){

        }
        public List<ConteudoResposta> conteudoResposta { get; set; }
        public string FraseParaCorrecao { get; set; }
        public int TotalSize { get; set; }
    }
}