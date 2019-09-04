using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TaCertoForms.Models{
    public class TipoQuestao{
        [Key]
        int IdTipoQuestao { get; set; }
        string Nome { get; set; }
        string Descricao { get; set; }
    }
}