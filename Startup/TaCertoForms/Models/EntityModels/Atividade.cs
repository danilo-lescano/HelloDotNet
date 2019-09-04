using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TaCertoForms.Models{
    public class Atividade{
        [Key]
        int IdAtividade { get; set; }
        int IdTurmaDisciplinaProfessor { get; set; }
        string DataInicio { get; set; }
        string DataFim { get; set; }
        int NumeroTentativas { get; set; }
        bool IsAleatorio { get; set; }
        bool IsProva { get; set; }

        TurmaDisciplinaProfessor TurmaDisciplinaProfessor { get; set; }
        List<Questao> QuestoeList { get; set; }
        List<AtividadeRespostaAluno> AtividadeRespostaAlunoList { get; set; }
    }
}