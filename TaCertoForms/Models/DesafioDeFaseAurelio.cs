using System;
using System.Collections.Generic;

namespace TaCertoForms.Models
{
    public class DesafioDeFaseAurelio : DesafioDeFase
    {
        public struct ConteudoResposta{
            int index;
            string palavra;
            bool eApendice;
            string apendice;
        }
        public DesafioDeFaseAurelio(int id, int faseId, string significado, string dica,
            int index, string palavra, bool eApendice, string apendice,
            string fraseParaCorrecao, int totalSize){

        }
        public string FraseParaCorrecao { get; set; }
        public int TotalSize { get; set; }
    }
}