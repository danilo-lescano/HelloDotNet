using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace TaCertoForms.Models{
    public class TurmaDisciplinaProfessor{
        [Key]
        int IdTurmaDisciplinaProfessor { get; set; }
        int IdTurma { get; set; }
        int IdDisciplinaProfessor { get; set; }
    }
}