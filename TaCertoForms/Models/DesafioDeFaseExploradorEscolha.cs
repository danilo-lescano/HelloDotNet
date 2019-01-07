using System;
using System.Collections.Generic;
using TaCertoForms.Models;
namespace TaCertoForms.Models
{
    public class DesafioDeFaseExploradorEscolha : DesafioDeFase
    {
        public struct PalavraExWrapper{
            int equivalente;
            bool emoji;
            string conteudo;
        }
        public List<PalavraExWrapper> Coluna1 { get; set; }
        public List<PalavraExWrapper> Coluna2 { get; set; }
    }
}