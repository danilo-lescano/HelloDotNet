using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaCertoForms.Models{
    [Table("TipoQuestao")]
    public class TipoQuestao{
        [Key]
        public int IdTipoQuestao { get; set; }
		[MaxLength(150)]
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}