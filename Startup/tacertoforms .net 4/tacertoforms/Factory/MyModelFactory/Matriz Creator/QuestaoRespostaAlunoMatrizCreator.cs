using System.Collections.Generic;
using System.Web;

using TaCertoForms.Models;

namespace TaCertoForms.Factory
{
    //CLASSE QuestaoRespostaAlunoMatrizCreator - Responsavel por pegar no banco de dados apenas as QuestaoRespostaAlunos relacionadas a uma determinada matriz
    public class QuestaoRespostaAlunoMatrizCreator : BaseCreator, IFactoryQuestaoRespostaAluno
    {
        public QuestaoRespostaAlunoMatrizCreator(HttpSessionStateBase session) : base(session) { }

        public QuestaoRespostaAluno CreateQuestaoRespostaAluno(QuestaoRespostaAluno questaoRespostaAluno)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteQuestaoRespostaAluno(int? id)
        {
            throw new System.NotImplementedException();
        }

        public QuestaoRespostaAluno EditQuestaoRespostaAluno(QuestaoRespostaAluno questaoRespostaAluno)
        {
            throw new System.NotImplementedException();
        }

        public QuestaoRespostaAluno FindQuestaoRespostaAluno(int? id)
        {
            throw new System.NotImplementedException();
        }

        public List<QuestaoRespostaAluno> FindQuestaoRespostaAlunoByQuestao(int? idQuestao)
        {
            throw new System.NotImplementedException();
        }

        public List<QuestaoRespostaAluno> QuestaoRespostaAlunoList()
        {
            throw new System.NotImplementedException();
        }
    }
}