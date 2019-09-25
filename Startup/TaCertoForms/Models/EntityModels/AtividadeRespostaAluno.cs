using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaCertoForms.Models{
    public class AtividadeRespostaAluno{
        [Key]
        public int IdAtividadeRespostaAluno { get; set; }
        public int IdAtividade { get; set; }
        public Atividade Atividade { get; set; }
        public int IdAluno { get; set; }
        [ForeignKey("IdAluno")]
        public Pessoa Aluno { get; set; }
        public DateTime DataEnvio { get; set; }
        public float Nota { get; set; }
        public int TempoTotalMilisegundos { get; set; }

        public List<QuestaoRespostaAluno> QuestaoRespostaAlunoList { get; set; }
    }
}