using System.Collections.Generic;

using TaCertoForms.Models;

namespace TaCertoForms.Factory{
    public interface IFactoryTipoQuestao{
        TipoQuestao FindTipoQuestao(int? id);
        List<TipoQuestao> TipoQuestaoList();
        TipoQuestao CreateTipoQuestao(TipoQuestao tipoQuestao);
        TipoQuestao EditTipoQuestao(TipoQuestao tipoQuestao);
        bool DeleteTipoQuestao(int? id);
    }
}