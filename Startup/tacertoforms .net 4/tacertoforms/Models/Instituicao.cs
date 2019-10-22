using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaCertoForms.Models{
    public class Instituicao{
        [Key]
        public int IdInstituicao { get; set; }        
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public int IdEnderecoPrincipal { get; set; }
        public int IdEnderecoCobranca { get; set; }
    }
}