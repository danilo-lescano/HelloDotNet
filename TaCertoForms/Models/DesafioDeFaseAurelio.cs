using System;
using System.Collections.Generic;

namespace TaCertoForms.Models
{
    public class DesafioDeFaseAurelio : IDesafioDeFase
    {
        public struct ConteudoResposta{
            int index;
            string palavra;
            bool eApendice;
            string apendice;
        }
        public int Id { get; set; }
        public int FaseId { get; set; }
        public string FraseParaCorrecao { get; set; }
        public int TotalSize { get; set; }
        public string Significado { get; set; }
        public string Dica { get; set; }
    }
}