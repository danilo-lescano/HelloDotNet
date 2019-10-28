using System.Collections.Generic;
using TaCertoForms.Models;

namespace TaCertoForms.Factory{
    public interface IFactoryDisciplinaTurma{
        DisciplinaTurma DisciplinaTurma(int? id);
        List<DisciplinaTurma> DisciplinaTurmaList();
    }
}