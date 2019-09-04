using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TaCertoForms.Models{
    public class Pessoa{
        [Key]
        int IdPessoa { get; set; }
        int IdInstituicao { get; set; }
        int IdPessoaLicenca { get; set; }
        string Nome { get; set; }
        string CPF { get; set; }
        string Email { get; set; }
        string Senha { get; set; }

        Instituicao Instituicao { get; set; }
        PessoaLicenca PessoaLicenca { get; set; }
        List<PerfilPessoa> PerfilPessoaList { get; set; }
        //se aluno
        List<TurmaAluno> TurmaAlunoList { get; set; }
        List<AtividadeRespostaAluno> AtividadeRespostaAlunoList { get; set; }
        //se professor
        List<DisciplinaProfessor> DisciplinaProfessorList { get; set; }
    }
}