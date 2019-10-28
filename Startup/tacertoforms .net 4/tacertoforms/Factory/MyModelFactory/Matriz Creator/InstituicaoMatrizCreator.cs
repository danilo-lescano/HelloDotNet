using System.Linq;
using System.Collections.Generic;
using TaCertoForms.Models;
using TaCertoForms.Contexts;

namespace TaCertoForms.Factory{
    //CLASSE InstituicaoMatrizCreator - Responsavel por pegar no banco de dados apenas as Instituicoes relacionadas a uma determinada matriz
    public class InstituicaoMatrizCreator : BaseCreator, IFactoryInstituicao{
        public InstituicaoMatrizCreator(int IdMatriz, int IdPessoa) : base(IdMatriz,IdPessoa) {}

        public Instituicao FindInstituicao(int? id){
            if(id == null) return null;
            Context db = new Context();
            Instituicao instituicao = db.Instituicao.Find(id);
            if(instituicao == null) return null;
            if(instituicao.IdInstituicao == IdMatriz || (instituicao.IdMatriz != null && instituicao.IdMatriz == IdMatriz))
                return instituicao;
            db.Dispose();
            return null;
        }
        public List<Instituicao> InstituicaoList(){
            Context db = new Context();
            
            List<Instituicao> instituicaoList = db.Instituicao.Where(i => i.IdInstituicao == IdMatriz || (i.IdMatriz != null && i.IdMatriz == IdMatriz)).ToList();
            if(instituicaoList == null || instituicaoList.Count == 0) return null;

            db.Dispose();
            return instituicaoList;
        }

        public Instituicao CreateInstituicao(Instituicao Instituicao){
            throw new System.NotImplementedException();
        }

        public Instituicao EditInstituicao(Instituicao Instituicao){
            throw new System.NotImplementedException();
        }

        public bool DeleteInstituicao(int? id){
            throw new System.NotImplementedException();
        }
    }
}