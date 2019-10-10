using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace tacertoforms.Models {
    public class Atividade {
        [Key]
        public int IdAtividade { get; set; }
        public int IdTurmaDisciplinaProfessor { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int NumeroTentativas { get; set; }
        public bool IsAleatorio { get; set; }
        public bool IsProva { get; set; }
    }
}