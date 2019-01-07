using System;
using System.Collections.Generic;
using Util;

namespace TaCertoForms.Models{
    public class DesafioDeFaseAurelio : DesafioDeFase{
        public List<ConteudoRespostaStruct> ConteudoResposta { get; set; }
        public string FraseParaCorrecao { get; set; }
        public int TotalSize { get; set; }
    }
}