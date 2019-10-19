using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TaCertoForms.Models{
    public class Licenca{
        [Key]
        public int IdLicenca { get; set; }
        public int IdInstituicao { get; set; }
        public int NumeroDeLinceca { get; set; }
        public string ValidadeLicenca { get; set; }
    }
}