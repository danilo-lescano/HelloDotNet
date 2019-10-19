using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
//ok
namespace tacertoforms.Models {
    public class Disciplina {
        [Key]
        public int IdDisciplina { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}