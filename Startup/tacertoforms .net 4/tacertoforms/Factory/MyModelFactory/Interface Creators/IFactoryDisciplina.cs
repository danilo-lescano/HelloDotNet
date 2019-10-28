using System.Collections.Generic;
using TaCertoForms.Models;

namespace TaCertoForms.Factory{
    public interface IFactoryDisciplina{
        Disciplina FindDisciplina(int? id);
        List<Disciplina> DisciplinaList();
        Disciplina CreateDisciplina(int? id);
        Disciplina EditDisciplina(int? id);
        bool DeleteDisciplina(int? id);
    }
}