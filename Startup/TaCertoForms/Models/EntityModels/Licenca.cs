using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace TaCertoFormsModel{
    public class Licenca{
        [Key]
        int IdLicenca { get; set; }
        int IdInstituicao { get; set; }
        int NumeroDeLinceca { get; set; }
        string ValidadeLicenca { get; set; }

        Instituicao Instituicao { get; set; }
    }
}