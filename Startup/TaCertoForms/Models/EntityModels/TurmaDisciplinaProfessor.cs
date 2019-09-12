using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TaCertoForms.Models{
    public class TurmaDisciplinaProfessor{
        [Key]
        public int IdTurmaDisciplinaProfessor { get; set; }
        public int IdTurma { get; set; }
        public int IdDisciplinaProfessor { get; set; }

        public List<Atividade> AtividadeList { get; set; }
        public List<DisciplinaProfessor> DisciplinaProfessorList { get; set; }
    }
}