using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TaCertoForms.Models{
    public class Instituicao{
        [Key]
        public int IdInstituicao { get; set; }
        public int IdEnderecoPrincipal { get; set; }
        public int IdEnderecoCobranca { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }

        //public Endereco EnderecoCobranca { get; set; }
        //public Endereco EnderecoPrincipal { get; set; }
        //public List<Turma> TurmaList { get; set; }
        //public List<Pessoa> PessoaList { get; set; }
        //public List<Licenca> LicencaList { get; set; }
    }
}