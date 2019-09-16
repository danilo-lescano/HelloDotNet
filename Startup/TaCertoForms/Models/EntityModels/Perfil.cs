using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TaCertoForms.Models{
    public class Perfil{
        [Key]
        public int IdPerfil { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public List<PerfilPessoa> PerfilPessoas { get; set; }
    }
}