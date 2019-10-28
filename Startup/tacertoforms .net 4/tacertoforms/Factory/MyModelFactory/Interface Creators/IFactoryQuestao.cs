using System.Collections.Generic;
using TaCertoForms.Models;

namespace TaCertoForms.Factory{
    public interface IFactoryQuestao{
        Questao Questao(int? id);
        List<Questao> QuestaoList();
    }
}