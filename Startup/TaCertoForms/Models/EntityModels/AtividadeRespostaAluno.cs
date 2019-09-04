using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TaCertoForms.Models{
    public class AtividadeRespostaAluno{
        [Key]
        int IdAtividadeRespostaAluno { get; set; }
        int IdAtividade { get; set; }
        int IdPessoa { get; set; }
        string DataEnvio { get; set; }
        float Nota { get; set; }
        string TempoTotal { get; set; }

        Pessoa Aluno { get; set; }
        Atividade Atividade { get; set; }
        List<QuestaoRespostaAluno> QuestaoRespostaAlunoList { get; set; }
    }
}