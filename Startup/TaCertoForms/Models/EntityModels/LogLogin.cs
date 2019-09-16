using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TaCertoForms.Models{
    public class LogLogin{
        [Key]
        public int IdLogLoggin { get; set; }
        public int IdPessoa { get; set; }
        public string HoraAcesso { get; set; }
        public string Plataforma { get; set; }
        public string DeviceId { get; set; }

        //public Pessoa Pessoa { get; set; }
    }
}