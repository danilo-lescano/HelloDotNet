using System.Collections.Generic;
using TaCertoForms.Models;

namespace TaCertoForms.Factory{
    public interface IFactoryTurma{
        Turma FindTurma(int? id);
        List<Turma> TurmaList();
        Turma CreateTurma(int? id);
        Turma EditTurma(int? id);
        bool DeleteTurma(int? id);
    }
}