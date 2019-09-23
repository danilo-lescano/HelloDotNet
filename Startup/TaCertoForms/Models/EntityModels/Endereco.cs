using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TaCertoForms.Models{
    public class Endereco{
        [Key]
        public int IdEndereco { get; set; }
        public string Pais { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string CEP { get; set; }

        public List<Instituicao> EnderecoPrincipalList { get; set; }
        public List<Instituicao> EnderecoCobrancaList { get; set; }
    }
}