using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace TaCertoFormsModel{
    public class Instituicao{
        [Key]
        int IdInstituicao { get; set; }
        int IdEnderecoPrincipal { get; set; }
        int IdEnderecoCobranca { get; set; }
        string RazaoSocial { get; set; }
        string NomeFantasia { get; set; }
        string CNPJ { get; set; }
    }
}