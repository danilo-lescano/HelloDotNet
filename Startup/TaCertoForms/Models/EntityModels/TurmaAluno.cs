using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaCertoForms.Models{
    [Table("TurmaAluno")]
    public class TurmaAluno{
        [Key]
        public int IdTurmaAluno { get; set; }
        public int IdTurma { get; set; }
        public int IdPessoa { get; set; }

        [ForeignKey("IdTurma")]
        public Turma Turma { get; set; }
        [ForeignKey("IdPessoa")]
        public Pessoa Pessoa { get; set; }
    }
}