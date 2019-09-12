using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TaCertoForms.Models{
    public class Turma{
        [Key]
        public int IdTurma { get; set; }
        public int IdInstituicao { get; set; }
        public string Serie { get; set; }
        public string Periodo { get; set; }
        public string Ano { get; set; }

        public Instituicao Instituicao { get; set; }
        public List<TurmaAluno> TurmaAlunoList { get; set; }
        public List<TurmaDisciplinaProfessor> TurmaDisciplinaProfessorList { get; set; }
    }
}