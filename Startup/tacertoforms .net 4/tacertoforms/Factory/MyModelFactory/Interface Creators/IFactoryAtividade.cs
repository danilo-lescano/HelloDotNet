using System.Collections.Generic;
using TaCertoForms.Models;

namespace TaCertoForms.Factory{
    public interface IFactoryAtividade{
        Atividade FindAtividade(int? id);
        List<Atividade> AtividadeList();
    }
}