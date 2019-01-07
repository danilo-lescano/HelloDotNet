using System;
using System.Collections.Generic;
using TaCertoForms.Models;
using Util;

namespace TaCertoForms.Models{
    public class DesafioDeFaseExploradorEscolha : DesafioDeFase{
        public bool Palavra { get; set; }
        public List<PalavraExWrapperStruct> PalavraExWrapper { get; set; }
    }
}