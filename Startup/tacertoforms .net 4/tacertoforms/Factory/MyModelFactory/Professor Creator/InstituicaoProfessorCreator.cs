using System.Linq;
using System.Collections.Generic;
using TaCertoForms.Models;
using TaCertoForms.Contexts;

namespace TaCertoForms.Factory{
    //CLASSE InstituicaoProfessorCreator - Responsavel por pegar no banco de dados apenas as Instituicoes relacionadas a uma determinada matriz
    public class InstituicaoProfessorCreator : BaseCreator, IFactoryInstituicao{
        public InstituicaoProfessorCreator(int IdMatriz, int IdPessoa) : base(IdMatriz,IdPessoa) {}
        public Instituicao CreateInstituicao(Instituicao instituicao){
            throw new System.NotImplementedException();
        }

        public bool DeleteInstituicao(int? id){
            throw new System.NotImplementedException();
        }

        public Instituicao EditInstituicao(Instituicao instituicao){
            throw new System.NotImplementedException();
        }

        public Instituicao FindInstituicao(int? id){
            throw new System.NotImplementedException();
        }

        public List<Instituicao> InstituicaoList(){
            throw new System.NotImplementedException();
        }
    }
}