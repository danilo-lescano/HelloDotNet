using System.Collections.Generic;
using TaCertoForms.Models;

namespace TaCertoForms.Factory{
    public interface IFactoryAtividade{
        Atividade FindAtividade(int? id);
        List<Atividade> AtividadeList();
        Atividade CreateAtividade(int? id);
        Atividade EditAtividade(int? id);
        bool DeleteAtividade(int? id);
    }
}