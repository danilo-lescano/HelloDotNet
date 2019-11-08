using System.Collections.Generic;

using TaCertoForms.Models;

namespace TaCertoForms.Factory
{
    public interface IFactoryAtividadeRespostaAluno
    {
        AtividadeRespostaAluno FindAtividadeRespostaAluno(int? id);
        List<AtividadeRespostaAluno> AtividadeRespostaAlunoList();
        AtividadeRespostaAluno CreateAtividadeRespostaAluno(AtividadeRespostaAluno atividadeRespostaAluno);
        AtividadeRespostaAluno EditAtividadeRespostaAluno(AtividadeRespostaAluno atividadeRespostaAluno);
        bool DeleteAtividadeRespostaAluno(int? id);
    }
}