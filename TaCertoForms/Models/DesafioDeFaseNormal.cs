using System;
using System.Collections.Generic;
using TaCertoForms.Models;
namespace TaCertoForms.Models
{
    public class DesafioDeFaseNormal : DesafioDeFase{
        public DesafioDeFaseNormal(){

        }
        public string Palavra { get; set; }
        public bool eCorreto { get; set; }
    }
}