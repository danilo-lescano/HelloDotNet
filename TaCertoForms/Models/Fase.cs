using System;
using System.Collections.Generic;
using TaCertoForms.Models;
namespace TaCertoForms.Models
{
    public class Fase
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Chave { get; set; }
        public int IdTipoFase { get; set; }
        public string Descricao { get; set; }
    }
    
}