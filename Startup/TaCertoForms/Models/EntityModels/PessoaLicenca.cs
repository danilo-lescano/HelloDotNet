using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TaCertoForms.Models{
    public class PessoaLicenca{
        [Key]
        public int IdPessoaLicenca { get; set; }
        public int IdPessoa { get; set; }
        public int IdLicenca { get; set; }
        public bool IsAtivo { get; set; }

        //public Pessoa Pessoa { get; set; }
        //public Licenca Licenca { get; set; }
    }
}