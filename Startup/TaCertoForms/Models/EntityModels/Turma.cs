using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TaCertoForms.Models{
    public class Turma{
        [Key]
        public int IdTurma { get; set; }
        public int IdInstituicao { get; set; }
        public string Serie { get; set; }
        public Periodo Periodo { get; set; }
    }
}