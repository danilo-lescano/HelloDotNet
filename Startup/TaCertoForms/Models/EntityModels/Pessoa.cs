using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TaCertoForms.Models{
    public class Pessoa{
        [Key]
        public int IdPessoa { get; set; }
        public int IdInstituicao { get; set; }
        public int IdPessoaLicenca { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public Instituicao Instituicao { get; set; }
        public PessoaLicenca PessoaLicenca { get; set; }
        public List<PerfilPessoa> PerfilPessoaList { get; set; }
        //se aluno
        public List<TurmaAluno> TurmaAlunoList { get; set; }
        public List<AtividadeRespostaAluno> AtividadeRespostaAlunoList { get; set; }
        //se professor
        public List<DisciplinaProfessor> DisciplinaProfessorList { get; set; }
    }
}