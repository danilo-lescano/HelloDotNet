using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TaCertoForms.Models{
    public class Disciplina{
        [Key]
        public int IdDisciplina { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public List<DisciplinaProfessor> DisciplinaProfessor { get; set; }
    }
}