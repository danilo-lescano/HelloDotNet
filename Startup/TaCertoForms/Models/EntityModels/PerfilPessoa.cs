using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TaCertoForms.Models{
    public class PerfilPessoa{
        [Key]
        public int IdPerfilPessoa { get; set; }
        public int IdPerfil { get; set; }
        public Perfil Perfil { get; set; }
        public int IdPessoa { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}