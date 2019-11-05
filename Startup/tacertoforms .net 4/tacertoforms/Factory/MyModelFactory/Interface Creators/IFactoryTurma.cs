using System.Collections.Generic;

using TaCertoForms.Models;

namespace TaCertoForms.Factory{
    public interface IFactoryTurma{
        Turma FindTurma(int? id);
        List<Turma> TurmaList();
        Turma CreateTurma(Turma turma);
        Turma EditTurma(Turma turma);
        bool DeleteTurma(int? id);
    }
}