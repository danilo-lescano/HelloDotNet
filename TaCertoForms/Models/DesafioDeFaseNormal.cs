using System;
using System.Collections.Generic;

namespace TaCertoForms.Models
{
    public class DesafioDeFaseNormal {
        private int id;
        public int Id { get; set; }
        private int faseId;
        public int FaseId { get; set; }

        public string Significado { get; set; }

        public string Dica { get; set; }
        public string Palavra { get; set; }
        public bool eCorreto { get; set; }
    }
    
}