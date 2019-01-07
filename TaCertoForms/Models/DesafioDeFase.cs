using System;
using System.Collections.Generic;
using TaCertoForms.Models;
namespace TaCertoForms.Models
{
    public class DesafioDeFase{

        public DesafioDeFase(){
        
        }
        public int Id { get; set; }
        public int FaseId { get; set; }
        public string Significado { get; set; }
        public string Dica { get; set; }
    }
}