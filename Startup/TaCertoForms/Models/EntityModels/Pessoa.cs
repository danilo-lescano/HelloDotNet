using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace TaCertoForms.Models{
    public class Pessoa{
       [Key]
       int IdPessoa { get; set; }
       int IdInstituicao { get; set; }
       List<PerfilPessoa> PerfilPessoaLista { get; set; }
       string Nome { get; set; }
       string CPF { get; set; }
       string Email { get; set; }
       string Senha { get; set; }
    }
}