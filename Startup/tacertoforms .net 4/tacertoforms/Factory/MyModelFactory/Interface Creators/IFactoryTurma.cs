using System.Collections.Generic;
using TaCertoForms.Models;

namespace TaCertoForms.Factory{
    public interface IFactoryTurma{
        Turma FindTurma(int? id);
        List<Turma> TurmaList();
    }
}