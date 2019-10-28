using System.Collections.Generic;
using TaCertoForms.Models;

namespace TaCertoForms.Factory{
    public interface IFactoryEndereco{
        Endereco FindEndereco(int? id);
        List<Endereco> EnderecoList();
        Endereco CreateEndereco(int? id);
        Endereco EditEndereco(int? id);
        bool DeleteEndereco(int? id);
    }
}