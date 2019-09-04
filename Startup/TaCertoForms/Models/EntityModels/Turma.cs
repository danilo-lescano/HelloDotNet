using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TaCertoForms.Models{
    public class Turma{
        [Key]
        int IdTurma { get; set; }
        int IdInstituicao { get; set; }
        string Serie { get; set; }
        string Periodo { get; set; }
        string Ano { get; set; }

        Instituicao Instituicao { get; set; }
        List<TurmaAluno> TurmaAlunoList { get; set; }
        List<TurmaDisciplinaProfessor> TurmaDisciplinaProfessorList { get; set; }
    }
}