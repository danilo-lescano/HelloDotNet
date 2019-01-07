using System;
using System.Collections.Generic;
using TaCertoForms.Models;
using Util;

namespace TaCertoForms.Models{
    public class DesafioDeFaseExploradorColuna : IDesafioDeFase{
        private int id;
        public int Id { get{return id;} set{id = value;} }
        private int faseId;
        public int FaseId { get{return faseId;} set{faseId = value;} }
        public string significado;
        public string Significado { get{return significado;} set{significado = value;} }
        public string dica;
        public string Dica { get{return dica;} set{dica = value;} }
        public bool Palavra { get; set; }
        public List<ColunaStruct> Coluna1 { get; set; }
        public List<ColunaStruct> Coluna2 { get; set; }
    }
}