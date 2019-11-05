using System.Collections.Generic;

using TaCertoForms.Models;

namespace TaCertoForms.Factory{
    public interface IFactoryDisciplina{
        Disciplina FindDisciplina(int? id);
        List<Disciplina> DisciplinaList();
        Disciplina CreateDisciplina(Disciplina disciplina);
        Disciplina EditDisciplina(Disciplina disciplina);
        bool DeleteDisciplina(int? id);
    }
}