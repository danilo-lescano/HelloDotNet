using System;
using System.Collections.Generic;
using TaCertoForms.Models;
namespace TaCertoForms.Models
{
    public class DesafioDeFaseExploradorColuna : DesafioDeFase
    {
        public struct Coluna{
            int equivalente;
            bool emoji;
            string conteudo;
        }
        public List<Coluna> Coluna1 { get; set; }
        public List<Coluna> Coluna2 { get; set; }
    }
}