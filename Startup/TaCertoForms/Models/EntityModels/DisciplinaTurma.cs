using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaCertoForms.Models{
    [Table("DisciplinaTurma")]
    public class DisciplinaTurma {
        [Key]
        public int IdDisciplinaTurma { get; set; }
        public int IdDisciplina { get; set; }
        public int IdTurma { get; set; }

        [ForeignKey("IdDisciplina")]
        public Disciplina Disciplina { get; set; }
        [ForeignKey("IdTurma")]
        public Turma Turma { get; set; }
    }
}