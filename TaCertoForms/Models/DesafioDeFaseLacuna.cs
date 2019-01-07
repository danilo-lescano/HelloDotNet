using System;
using System.Collections.Generic;
using TaCertoForms.Models;
namespace TaCertoForms.Models
{
    public class DesafioDeFaseLacuna : DesafioDeFase
    {
        public struct Resposta{
            string conteudo;
            int posicao;
        }
        public struct FraseXlacuna{
            bool eFrase;
            string conteudo;
        }
        public int FaseId { get; set; }
        public List<Resposta> ListaResposta { get; set; }
        public List<FraseXlacuna> ListaFraseXlacuna { get; set; }
    }
}