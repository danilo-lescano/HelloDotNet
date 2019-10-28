using System.Collections.Generic;
using TaCertoForms.Models;

namespace TaCertoForms.Factory{
    public interface IFactoryTipoQuestao{
        TipoQuestao FindTipoQuestao(int? id);
        List<TipoQuestao> TipoQuestaoList();
    }
}