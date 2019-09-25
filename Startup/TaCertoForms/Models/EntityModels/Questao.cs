using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TaCertoForms.Models{
    public class Questao{
        [Key]
        public int IdQuestao { get; set; }
        public int IdAtividade { get; set; }
        public Atividade Atividade { get; set; }
        public int IdTipoQuestao { get; set; }
        public TipoQuestao TipoQuestao { get; set; }
        public string Titulo { get; set; }
        public string Enunciado { get; set; }
        public string JsonQuestao { get; set; }
        public int PesoNota { get; set; }

        public List<QuestaoRespostaAluno> QuestaoRespostaAlunoList { get; set; }
    }
}