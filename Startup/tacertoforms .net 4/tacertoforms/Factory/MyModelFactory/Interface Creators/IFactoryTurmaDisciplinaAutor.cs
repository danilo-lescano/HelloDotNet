using System.Collections.Generic;
using TaCertoForms.Models;

namespace TaCertoForms.Factory{
    public interface IFactoryTurmaDisciplinaAutor{
        TurmaDisciplinaAutor FindTurmaDisciplinaAutor(int? id);
        List<TurmaDisciplinaAutor> TurmaDisciplinaAutorList();
    }
}