using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TaCertoForms.Models{
    public class DisciplinaProfessor{
        [Key]
        public int IdDisciplinaProfessor { get; set; }
        public int IdDisciplina { get; set; }
        public Disciplina Disciplina { get; set; }
        public int IdPessoa { get; set; }
        public Pessoa Professor { get; set; }

        public List<TurmaDisciplinaProfessor> TurmaDisciplinaProfessorList { get; set; }
    }
}