using System;
using System.Collections.Generic;
using TaCertoForms.Models;
namespace TaCertoForms.Models
{
    public class DesafioDeFaseExploradorColuna //: IDesafioDeFase
    {
        public struct Coluna{
            int equivalente;
            bool emoji;
            string conteudo;
        }
        private int Id { get; set; }
        public int FaseId { get; set; }
        public List<Coluna> Coluna1 { get; set; }
        public List<Coluna> Coluna2 { get; set; }
        public string Significado { get; set; }
        public string Dica { get; set; }
    }
}