using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tacertoforms.Models
{
    public class ViewModelTurma
    {
        public int IdTurma { get; set; }
        public int IdInstituicao { get; set; }
        public string Serie { get; set; }
        public Periodo Periodo { get; set; }

        public int IdTurmaAluno { get; set; }
        public List<Pessoa> Alunos { get; set; } = new List<Pessoa>();
    }
}