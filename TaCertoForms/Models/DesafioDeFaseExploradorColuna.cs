using System;
using System.Collections.Generic;
using TaCertoForms.Models;
using Util;

namespace TaCertoForms.Models{
    public class DesafioDeFaseExploradorColuna : DesafioDeFase{
        public bool Palavra { get; set; }
        public List<ColunaStruct> Coluna1 { get; set; }
        public List<ColunaStruct> Coluna2 { get; set; }
    }
}