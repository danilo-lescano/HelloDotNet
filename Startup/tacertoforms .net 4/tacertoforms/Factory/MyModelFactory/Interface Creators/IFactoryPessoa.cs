using System.Collections.Generic;
using TaCertoForms.Models;

namespace TaCertoForms.Factory{
    public interface IFactoryPessoa{
        Pessoa FindPessoa(int? id);
        List<Pessoa> PessoaList();
    }
}