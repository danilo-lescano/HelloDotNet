using System.Collections.Generic;

using TaCertoForms.Models;

namespace TaCertoForms.Factory{
    public interface IFactoryTurmaDisciplinaAutor{
        TurmaDisciplinaAutor FindTurmaDisciplinaAutor(int? id);
        List<TurmaDisciplinaAutor> TurmaDisciplinaAutorList();
        TurmaDisciplinaAutor CreateTurmaDisciplinaAutor(TurmaDisciplinaAutor turmaDisciplinaAutor);
        TurmaDisciplinaAutor EditTurmaDisciplinaAutor(TurmaDisciplinaAutor turmaDisciplinaAutor);
        bool DeleteTurmaDisciplinaAutor(int? id);
    }
}