using System;
using System.Collections.Generic;
using TaCertoForms.Models;
namespace TaCertoForms.Models
{
    public class DesafioDeFaseNormal : IDesafioDeFase
    {
        public int Id { get; set; }
        public int FaseId { get; set; }
        public string Palavra { get; set; }
        public bool eCorreto { get; set; }
        public string Significado { get; set; }
        public string Dica { get; set; }
    }
}