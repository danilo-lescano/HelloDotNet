using System.Collections.Generic;
using TaCertoForms.Models;

namespace TaCertoForms.Factory{
    public interface IFactoryQuestao{
        Questao FindQuestao(int? id);
        List<Questao> QuestaoList();
        Questao CreateQuestao(Questao questao);
        Questao EditQuestao(Questao questao);
        bool DeleteQuestao(int? id);
    }
}