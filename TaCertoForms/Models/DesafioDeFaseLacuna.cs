using System;
using System.Collections.Generic;
using TaCertoForms.Models;
using Util;

namespace TaCertoForms.Models{
    public class DesafioDeFaseLacuna : DesafioDeFase{
        public List<RespostaStruct> Resposta { get; set; }
        public List<FraseXlacunaStruct> FraseXlacuna { get; set; }
    }
}