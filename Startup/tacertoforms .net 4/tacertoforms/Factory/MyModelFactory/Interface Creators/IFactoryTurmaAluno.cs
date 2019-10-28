using System.Collections.Generic;
using TaCertoForms.Models;

namespace TaCertoForms.Factory{
    public interface IFactoryTurmaAluno{
        TurmaAluno FindTurmaAluno(int? id);
        List<TurmaAluno> TurmaAlunoList();
        TurmaAluno CreateTurmaAluno(TurmaAluno turmaAluno);
        TurmaAluno EditTurmaAluno(TurmaAluno turmaAluno);
        bool DeleteTurmaAluno(int? id);
    }
}