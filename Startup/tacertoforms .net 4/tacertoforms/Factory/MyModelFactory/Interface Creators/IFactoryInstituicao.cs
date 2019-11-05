using System.Collections.Generic;

using TaCertoForms.Models;

namespace TaCertoForms.Factory{
    public interface IFactoryInstituicao{
        Instituicao FindInstituicao(int? id);
        List<Instituicao> InstituicaoList();
        Instituicao CreateInstituicao(Instituicao instituicao);
        Instituicao EditInstituicao(Instituicao instituicao);
        bool DeleteInstituicao(int? id);
    }
}