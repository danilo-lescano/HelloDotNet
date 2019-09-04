using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace TaCertoForms.Models{
    public class LicencaPessoa{
        [Key]
        int IdLicencaPessoa { get; set; }
        int IdPessoa { get; set; }
        bool IsAtivo { get; set; }
    }
}