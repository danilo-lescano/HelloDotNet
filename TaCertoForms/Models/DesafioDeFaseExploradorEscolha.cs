using System;
using System.Collections.Generic;
using TaCertoForms.Models;
using Util;

namespace TaCertoForms.Models
{
    public class DesafioDeFaseExploradorEscolha : DesafioDeFase
    {
        public List<PalavraExWrapper> Coluna1 { get; set; }
        public List<PalavraExWrapper> Coluna2 { get; set; }
    }
}