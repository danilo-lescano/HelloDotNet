using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TaCertoForms.Models{
    public class Instituicao{
        [Key]
        int IdInstituicao { get; set; }
        int IdEnderecoPrincipal { get; set; }
        int IdEnderecoCobranca { get; set; }
        string RazaoSocial { get; set; }
        string NomeFantasia { get; set; }
        string CNPJ { get; set; }

        Endereco EnderecoCobranca { get; set; }
        Endereco EnderecoPrincipal { get; set; }
        List<Turma> TurmaList { get; set; }
        List<Pessoa> PessoaList { get; set; }
        List<Licenca> LicencaList { get; set; }
    }
}