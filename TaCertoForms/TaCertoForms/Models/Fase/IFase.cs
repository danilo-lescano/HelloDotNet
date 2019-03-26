using System;
using System.Collections.Generic;
using TaCertoForms.Models;
using System.Runtime.Serialization.Json;
using Util;

namespace TaCertoForms.Models{
    public interface IFase{
        int Id { get; set; }
        int UsuarioId { get; set; }
        string Chave { get; set; }
        int IdTipoFase { get; set; }
        string Descricao { get; set; }
        List<IDesafioDeFase> Desafios{ get; set; }
    }
}