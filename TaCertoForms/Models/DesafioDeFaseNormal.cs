using System;
using System.Collections.Generic;
using TaCertoForms.Models;
using Util;

namespace TaCertoForms.Models{
    public class DesafioDeFaseNormal : DesafioDeFase{
        public string Palavra { get; set; }
        public bool eCorreto { get; set; }
    }
}