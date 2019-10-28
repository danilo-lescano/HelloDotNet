using System.Collections.Generic;
using TaCertoForms.Models;

namespace TaCertoForms.Factory{
    public interface IFactoryQuestao{
        Questao FindQuestao(int? id);
        List<Questao> QuestaoList();
        Questao CreateQuestao(int? id);
        Questao EditQuestao(int? id);
        bool DeleteQuestao(int? id);
    }
}