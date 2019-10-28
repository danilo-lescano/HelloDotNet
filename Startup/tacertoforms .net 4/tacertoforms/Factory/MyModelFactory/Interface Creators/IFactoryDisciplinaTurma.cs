using System.Collections.Generic;
using TaCertoForms.Models;

namespace TaCertoForms.Factory{
    public interface IFactoryDisciplinaTurma{
        DisciplinaTurma FindDisciplinaTurma(int? id);
        List<DisciplinaTurma> DisciplinaTurmaList();
        DisciplinaTurma CreateDisciplinaTurma(int? id);
        DisciplinaTurma EditDisciplinaTurma(int? id);
        bool DeleteDisciplinaTurma(int? id);
    }
}