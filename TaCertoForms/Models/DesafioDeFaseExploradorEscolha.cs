using System;
using System.Collections.Generic;
using TaCertoForms.Models;
namespace TaCertoForms.Models
{
    public class DesafioDeFaseExploradorEscolha : IDesafioDeFase
    {
        public struct PalavraExWrapper{
            int equivalente;
            bool emoji;
            string conteudo;
        }
        private int Id { get; set; }
        public int FaseId { get; set; }
        public List<PalavraExWrapper> Coluna1 { get; set; }
        public List<PalavraExWrapper> Coluna2 { get; set; }
        public string Significado { get; set; }
        public string Dica { get; set; }
    }
}