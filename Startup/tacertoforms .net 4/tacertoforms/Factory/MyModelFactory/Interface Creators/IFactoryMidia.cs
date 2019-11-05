using System;
using System.Collections.Generic;

using TaCertoForms.Models;

namespace TaCertoForms.Factory{
    public interface IFactoryMidia{
        Midia CreateMidia(int? IdOrigem, string Tabela, Midia midia);
        bool DeleteMidia(Guid? id);
        Midia EditMidia(int? IdOrigem, string Tabela, Midia midia);
        Midia FindMidia(int? IdOrigem, string Tabela);
        bool HasPermissionMidia(int? IdOrigem, string Tabela);
        List<Midia> MidiaList(int? IdOrigem, string Tabela);        
    }
}