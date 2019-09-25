using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaCertoForms.Models{
    public class TurmaAluno{
        [Key]
        public int IdTurmaAluno { get; set; }
        public int IdTurma { get; set; }
        public Turma Turma { get; set; }
        public int IdAluno { get; set; }
        [ForeignKey("IdAluno")]
        public Pessoa Aluno { get; set; }
    }
}