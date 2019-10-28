using System.Collections.Generic;
using TaCertoForms.Models;

namespace TaCertoForms.Factory{
    public interface IFactoryPessoa{
        Pessoa FindPessoa(int? id);
        List<Pessoa> PessoaList();
        Pessoa CreatePessoa(int? id);
        Pessoa EditPessoa(int? id);
        bool DeletePessoa(int? id);
    }
}