using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TaCertoForms.Models{
    public class Atividade{
        [Key]
        public int IdAtividade { get; set; }
        public int IdTurmaDisciplinaProfessor { get; set; }
        public string DataInicio { get; set; }
        public string DataFim { get; set; }
        public int NumeroTentativas { get; set; }
        public bool IsAleatorio { get; set; }
        public bool IsProva { get; set; }

        //public TurmaDisciplinaProfessor TurmaDisciplinaProfessor { get; set; }
        //public List<Questao> QuestoeList { get; set; }
        //public List<AtividadeRespostaAluno> AtividadeRespostaAlunoList { get; set; }
    }
}