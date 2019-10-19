using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TaCertoForms.Models{
    public class DisciplinaTurma {
        [Key]
        public int IdDisciplinaTurma { get; set; }
        public int IdDisciplina { get; set; }
        public int IdTurma { get; set; }
    }
}