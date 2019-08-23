using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace TaCertoForms.Models{
    public class Turma{
        [Key]
        int IdTurma { get; set; }
        string Serie { get; set; }
        string Periodo { get; set; }
        int Ano { get; set; }
    }
}