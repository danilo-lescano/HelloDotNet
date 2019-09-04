using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TaCertoForms.Models{
    public class Endereco{
        [Key]
        int IdEndereco { get; set; }
        string Pais { get; set; }
        string UF { get; set; }
        string Cidade { get; set; }
        string Rua { get; set; }
        string Numero { get; set; }
        string Complemento { get; set; }
        string CEP { get; set; }
    }
}