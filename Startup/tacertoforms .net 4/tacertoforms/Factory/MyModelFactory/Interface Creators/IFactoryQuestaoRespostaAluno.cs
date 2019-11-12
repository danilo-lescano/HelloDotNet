using System.Collections.Generic;

using TaCertoForms.Models;

namespace TaCertoForms.Factory
{
    public interface IFactoryQuestaoRespostaAluno
    {
        QuestaoRespostaAluno FindQuestaoRespostaAluno(int? id);
        List<QuestaoRespostaAluno> FindQuestaoRespostaAlunoByQuestao(int? idQuestao);        
        List<QuestaoRespostaAluno> QuestaoRespostaAlunoList();
        QuestaoRespostaAluno CreateQuestaoRespostaAluno(QuestaoRespostaAluno questaoRespostaAluno);
        QuestaoRespostaAluno EditQuestaoRespostaAluno(QuestaoRespostaAluno questaoRespostaAluno);
        bool DeleteQuestaoRespostaAluno(int? id);
    }
}