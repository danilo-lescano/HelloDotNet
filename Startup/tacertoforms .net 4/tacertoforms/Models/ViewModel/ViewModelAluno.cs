using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tacertoforms.Models { 
    public class ViewModelAluno
    {
        public int IdPessoa { get; set; }
        public int IdInstituicao { get; set; }        
        public string NomeFantasia { get; set; }
        public Perfil Perfil { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public List<Turma> Turma { get; set; } = new List<Turma>();        
        public int IdTurmaAluno { get; set; }               
        public List<Instituicao> Instituicao { get; set; } = new List<Instituicao>();
       
    }
}