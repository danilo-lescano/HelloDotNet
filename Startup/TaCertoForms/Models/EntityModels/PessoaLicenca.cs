using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace TaCertoForms.Models{
    public class PessoaLicenca{
        [Key]
        int IdPessoaLicenca { get; set; }
        int IdPessoa { get; set; }
        int IdLicenca { get; set; }
        bool IsAtivo { get; set; }

        Pessoa Pessoa { get; set; }
        Licenca Licenca { get; set; }
    }
}