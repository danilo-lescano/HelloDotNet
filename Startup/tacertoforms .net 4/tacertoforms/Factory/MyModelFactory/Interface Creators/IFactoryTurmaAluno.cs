using System.Collections.Generic;
using TaCertoForms.Models;

namespace TaCertoForms.Factory{
    public interface IFactoryTurmaAluno{
        TurmaAluno FindTurmaAluno(int? id);
        List<TurmaAluno> TurmaAlunoList();
    }
}