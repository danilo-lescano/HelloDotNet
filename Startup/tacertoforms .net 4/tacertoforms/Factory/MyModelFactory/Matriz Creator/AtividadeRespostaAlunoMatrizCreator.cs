using System.Collections.Generic;
using System.Web;

using TaCertoForms.Models;

namespace TaCertoForms.Factory
{
    public class AtividadeRespostaAlunoMatrizCreator : BaseCreator, IFactoryAtividadeRespostaAluno
    {
        public AtividadeRespostaAlunoMatrizCreator(HttpSessionStateBase session) : base(session) { }

        public List<AtividadeRespostaAluno> AtividadeRespostaAlunoList()
        {
            throw new System.NotImplementedException();
        }

        public AtividadeRespostaAluno CreateAtividadeRespostaAluno(AtividadeRespostaAluno atividadeRespostaAluno)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteAtividadeRespostaAluno(int? id)
        {
            throw new System.NotImplementedException();
        }

        public AtividadeRespostaAluno EditAtividadeRespostaAluno(AtividadeRespostaAluno atividadeRespostaAluno)
        {
            throw new System.NotImplementedException();
        }

        public AtividadeRespostaAluno FindAtividadeRespostaAluno(int? id)
        {
            throw new System.NotImplementedException();
        }
    }
}