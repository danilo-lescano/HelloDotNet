using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TaCertoForms.Models{
    public class Midia{
        [Key]
        public int IdMidia { get; set; }
        public int IdEntidade { get; set; }
        public string TipoEntidade { get; set; }
        public int Ordem { get; set; }
        public string Extensao { get; set; }
        public string Caminho { get; set; }
    }
}