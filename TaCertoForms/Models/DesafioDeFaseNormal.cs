using System;
using System.Collections.Generic;
using TaCertoForms.Models;
namespace TaCertoForms.Models
{
    public class DesafioDeFaseNormal : IDesafioDeFase
    {
        int Id { get; set; }
        int FaseId { get; set; }
    }
}