using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TaCertoForms.Models{
    [Table("Atividade")]
    public class Atividade {
        [Key]
        public int IdAtividade { get; set; }
        public int IdTurmaDisciplinaAutor { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Titulo { get; set; }
        public int NumeroTentativas { get; set; }
        public bool IsAleatorio { get; set; }
        public bool IsProva { get; set; }


        //NAVIGATION PROPERTY
        public TurmaDisciplinaAutor TurmaDisciplinaAutor { get; set; }
    }
}