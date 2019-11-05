using System.Collections.Generic;
using TaCertoForms.Models;

namespace TaCertoForms.Factory{
    public interface IFactoryQuestao{
        Questao CreateQuestao(Questao questao);
        bool DeleteQuestao(int? id);
        Questao EditQuestao(Questao questao);
        Questao FindQuestao(int? id);
        List<Questao> FindQuestaoByTypeAndActivity(int? idAtividade, int? idTipoQuestao);
        List<Questao> QuestaoList();
    }
}