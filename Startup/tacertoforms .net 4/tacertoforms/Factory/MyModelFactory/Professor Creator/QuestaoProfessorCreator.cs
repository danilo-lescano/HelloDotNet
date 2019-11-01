using System.Linq;
using System.Collections.Generic;
using TaCertoForms.Models;
using TaCertoForms.Contexts;

namespace TaCertoForms.Factory{
    //CLASSE QuestaoProfessorCreator - Responsavel por pegar no banco de dados apenas as Questaos relacionadas a uma determinada matriz
    public class QuestaoProfessorCreator : BaseCreator, IFactoryQuestao{
        public QuestaoProfessorCreator(int IdMatriz, int IdPessoa) : base(IdMatriz,IdPessoa) {}

        public Questao CreateQuestao(Questao questao)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteQuestao(int? id)
        {
            throw new System.NotImplementedException();
        }

        public Questao EditQuestao(Questao questao)
        {
            throw new System.NotImplementedException();
        }

        public Questao FindQuestao(int? id)
        {
            throw new System.NotImplementedException();
        }

        public List<Questao> QuestaoList()
        {
            throw new System.NotImplementedException();
        }
    }
}