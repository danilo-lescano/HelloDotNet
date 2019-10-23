using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TaCertoForms.Models{
    [Table("TurmaDisciplinaAutor")]
    public class TurmaDisciplinaAutor{
        [Key]
        public int IdTurmaDisciplinaAutor { get; set; }
        public int IdAutor { get; set; }
        public int IdDisciplinaTurma { get; set; }       

        [ForeignKey("IdAutor")]
        public Pessoa Autor { get; set; }
        [ForeignKey("IdDisciplinaTurma ")]
        public DisciplinaTurma DisciplinaTurma { get; set; }
    }
}