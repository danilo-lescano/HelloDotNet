using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace TaCertoForms.Models{
    public class Questao{
        [Key]
        int IdQuestao { get; set; }
        int IdAtividade { get; set; }
        int IdTipoQuestao { get; set; }
        string Titulo { get; set; }
        string Enunciado { get; set; }
        string JsonQuestao { get; set; }
        int PesoNota { get; set; }
    }
}