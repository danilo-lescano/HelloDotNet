using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TaCertoForms.Models{
    public class AtividadeRespostaAluno{
        [Key]
        public int IdAtividadeRespostaAluno { get; set; }
        public int IdAtividade { get; set; }
        public int IdAluno { get; set; }
        public string DataEnvio { get; set; }
        public float Nota { get; set; }
        public string TempoTotal { get; set; }

        public Pessoa Aluno { get; set; }
        public Atividade Atividade { get; set; }
        public List<QuestaoRespostaAluno> QuestaoRespostaAlunoList { get; set; }
    }
}