using System.Collections.Generic;

using TaCertoForms.Models;

namespace TaCertoForms.Factory{
    public interface IFactoryDisciplinaTurma{
        DisciplinaTurma FindDisciplinaTurma(int? id);
        List<DisciplinaTurma> DisciplinaTurmaList();
        DisciplinaTurma CreateDisciplinaTurma(DisciplinaTurma disciplinaTurma);
        DisciplinaTurma EditDisciplinaTurma(DisciplinaTurma disciplinaTurma);
        bool DeleteDisciplinaTurma(int? id);
    }
}