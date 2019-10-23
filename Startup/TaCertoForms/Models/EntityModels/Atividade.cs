using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaCertoForms.Models{
    [Table("Atividade")]
    public class Atividade {
        [Key]
        public int IdAtividade { get; set; }
        public int IdTurmaDisciplinaAutor { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int NumeroTentativas { get; set; }
        public bool IsAleatorio { get; set; }
        public bool IsProva { get; set; }

        [ForeignKey("IdTurmaDisciplinaAutor")]
        public TurmaDisciplinaAutor TurmaDisciplinaAutor { get; set; }
    }
}