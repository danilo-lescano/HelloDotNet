using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TaCertoForms.Models{
    public class LogLogin{
        [Key]
        int IdLogLoggin { get; set; }
        int IdPessoa { get; set; }
        string HoraAcesso { get; set; }
        string Plataforma { get; set; }
        string DeviceId { get; set; }

        Pessoa Pessoa { get; set; }
    }
}