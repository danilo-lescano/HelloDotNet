using System;
using System.Collections.Generic;
using TaCertoForms.Models;
namespace TaCertoForms.Models
{
    public interface IDesafioDeFase<T>{

        int Id { get; set; }
        int FaseId { get; set; }
        string Significado { get; set; }
        string Dica { get; set; }
    }
}