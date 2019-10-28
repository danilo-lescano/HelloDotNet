using System.Collections.Generic;
using TaCertoForms.Models;

namespace TaCertoForms.Factory{
    public interface IFactoryDisciplina{
        Disciplina Disciplina(int? id);
        List<Disciplina> DisciplinaList();
    }
}