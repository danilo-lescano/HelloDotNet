using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
//ok
namespace tacertoforms.Models{
    public class Turma{
        [Key]
        public int IdTurma { get; set; }
        public int IdInstituicao { get; set; }
        public string Serie { get; set; }
        public Periodo Periodo { get; set; } //nullable + enum(matutino, vespertino, noturno, integral)
    }
}