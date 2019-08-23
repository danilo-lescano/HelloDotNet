using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace TaCertoForms.Models{
    public class AtividadeRespostaAluno{
       [Key]
       int IdAtividadeRespostaAluno { get; set; }
       int IdAtividade { get; set; }
       string DataEnvio { get; set; }
    }
}