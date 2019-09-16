using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TaCertoForms.Models{
    public class QuestaoRespostaAluno{
        [Key]
        public int IdQuestaoRespostaAluno { get; set; }
        public int IdAtividadeRespostaAluno { get; set; }
        public int IdQuestao { get; set; }
        public int NumAcerto { get; set; }
        public int NumErro { get; set; }
        public float Nota { get; set; }
        public string Tempo { get; set; }
        public string JsonResposta { get; set; }

        //public Questao Questao { get; set; }
        //public AtividadeRespostaAluno AtividadeRespostaAluno { get; set; }
    }
}