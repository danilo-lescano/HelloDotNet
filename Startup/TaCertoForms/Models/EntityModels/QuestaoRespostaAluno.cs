using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace TaCertoForms.Models{
    public class QuestaoRespostaAluno{
        [Key]
        int IdQuestaoRespostaAluno { get; set; }
        int IdAtividade { get; set; }
        int IdQuestao { get; set; }
        int NumAcerto { get; set; }
        int NumErro { get; set; }
        float Nota { get; set; }
        string Tempo { get; set; }
        string JsonResposta { get; set; }
    }
}