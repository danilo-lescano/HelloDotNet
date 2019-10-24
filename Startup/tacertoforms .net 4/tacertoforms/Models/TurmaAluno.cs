using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TaCertoForms.Models{
    [Table("TurmaAluno")]
    public class TurmaAluno{
        [Key]
        public int IdTurmaAluno { get; set; }
        public int IdTurma { get; set; }
        public int IdPessoa { get; set; }

        //NAVIGATION PROPERTY
        public Turma Turma { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}