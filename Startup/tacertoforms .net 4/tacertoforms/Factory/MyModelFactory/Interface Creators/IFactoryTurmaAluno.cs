using System.Collections.Generic;
using TaCertoForms.Models;

namespace TaCertoForms.Factory{
    public interface IFactoryTurmaAluno{
        TurmaAluno FindTurmaAluno(int? id);
        List<TurmaAluno> TurmaAlunoList();
        TurmaAluno CreateTurmaAluno(int? id);
        TurmaAluno EditTurmaAluno(int? id);
        bool DeleteTurmaAluno(int? id);
    }
}