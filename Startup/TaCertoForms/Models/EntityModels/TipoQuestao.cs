using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TaCertoForms.Models{
    public class TipoQuestao{
        [Key]
        public int IdTipoQuestao { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<Questao> QuestaoList { get; set; }
    }
}