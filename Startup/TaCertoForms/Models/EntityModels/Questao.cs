using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaCertoForms.Models{
    [Table("Questao")]
    public class Questao {
        [Key]
        public int IdQuestao { get; set; }
        public int IdAtividade { get; set; }
        public int IdTipoQuestao { get; set; }
        public string Titulo { get; set; }
        public string Enunciado { get; set; }
        public string JsonQuestao { get; set; }
        public int PesoNota { get; set; }

        [ForeignKey("IdAtividade")]
        public Atividade Atividade { get; set; }
        [ForeignKey("IdTipoQuestao")]
        public TipoQuestao TipoQuestao { get; set; }
    }
}