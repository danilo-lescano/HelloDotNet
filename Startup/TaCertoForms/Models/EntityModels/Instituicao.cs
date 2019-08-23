using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace TaCertoForms.Models{
    public class Instituicao{
       [Key]
       int IdInstituicao { get; set; }
       string Nome { get; set; }
    }
}