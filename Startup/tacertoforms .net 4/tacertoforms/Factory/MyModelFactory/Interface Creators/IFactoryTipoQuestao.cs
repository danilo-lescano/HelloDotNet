using System.Collections.Generic;
using TaCertoForms.Models;

namespace TaCertoForms.Factory{
    public interface IFactoryTipoQuestao{
        TipoQuestao FindTipoQuestao(int? id);
        List<TipoQuestao> TipoQuestaoList();
        TipoQuestao CreateTipoQuestao(int? id);
        TipoQuestao EditTipoQuestao(int? id);
        bool DeleteTipoQuestao(int? id);
    }
}