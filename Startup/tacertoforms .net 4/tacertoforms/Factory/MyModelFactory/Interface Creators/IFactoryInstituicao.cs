using System.Collections.Generic;
using TaCertoForms.Models;

namespace TaCertoForms.Factory{
    public interface IFactoryInstituicao{
        Instituicao FindInstituicao(int? id);
        List<Instituicao> InstituicaoList();
        Instituicao CreateInstituicao(int? id);
        Instituicao EditInstituicao(int? id);
        bool DeleteInstituicao(int? id);
    }
}