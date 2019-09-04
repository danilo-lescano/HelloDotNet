using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TaCertoForms.Models{
    public class TurmaAluno{
        [Key]
        int IdTurmaAluno { get; set; }
        int IdTurma { get; set; }
        int IdPessoa { get; set; }

        Turma Turma { get; set; }
        Pessoa Aluno { get; set; }
    }
}