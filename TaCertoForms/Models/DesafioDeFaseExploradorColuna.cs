using System;
using System.Collections.Generic;
using TaCertoForms.Models;
using Util;

namespace TaCertoForms.Models
{
    public class DesafioDeFaseExploradorColuna : DesafioDeFase
    {
        public List<Coluna> Coluna1 { get; set; }
        public List<Coluna> Coluna2 { get; set; }
    }
}