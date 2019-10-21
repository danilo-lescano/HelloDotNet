using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace tacertoforms.Models
{
    public class Midia  {
      [Key]
      public Guid IdMidia { get; set; }
      public int IdOrigem { get;set; }
      public string Tabela { get; set; }      
      public string Filename { get; set; }
      public string Link { get; set; }
      public string Extensao { get; set; }
      public TipoMidia Tipo { get; set; }
    }
}