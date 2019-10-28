using System.Collections.Generic;
using TaCertoForms.Models;

namespace TaCertoForms.Factory{
    public interface IFactoryTurmaDisciplinaAutor{
        TurmaDisciplinaAutor FindTurmaDisciplinaAutor(int? id);
        List<TurmaDisciplinaAutor> TurmaDisciplinaAutorList();
        TurmaDisciplinaAutor CreateTurmaDisciplinaAutor(int? id);
        TurmaDisciplinaAutor EditTurmaDisciplinaAutor(int? id);
        bool DeleteTurmaDisciplinaAutor(int? id);
    }
}