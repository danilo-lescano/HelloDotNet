using System;
using System.Collections.Generic;
using TaCertoForms.Models;
using Util;

namespace TaCertoForms.Models
{
    public class DesafioDeFaseLacuna : DesafioDeFase
    {
        public int FaseId { get; set; }
        public List<Resposta> ListaResposta { get; set; }
        public List<FraseXlacuna> ListaFraseXlacuna { get; set; }
    }
}