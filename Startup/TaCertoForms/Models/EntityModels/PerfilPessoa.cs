using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TaCertoForms.Models{
    public class PerfilPessoa{
        [Key]
        int IdPerfilPessoa { get; set; }
        int IdPerfil { get; set; }
        int IdPessoa { get; set; }

        Perfil Perfil { get; set; }
        Pessoa Pessoa { get; set; }
    }
}