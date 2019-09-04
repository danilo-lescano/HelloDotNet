using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace TaCertoFormsModel{
    public class Midia{
        [Key]
        int IdMidia { get; set; }
        int IdEntidade { get; set; }
        string TipoEntidade { get; set; }
        int Ordem { get; set; }
        string Extensao { get; set; }
        string Caminho { get; set; }
    }
}