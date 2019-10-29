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
            Context db = new Context();

            Instituicao instituicao_aux = db.Instituicao.Find(instituicao.IdInstituicao);
            if(instituicao_aux != null)
                return null;
            instituicao.IdMatriz = IdMatriz;
            Instituicao.IsMatriz = false;
            db.Instituicao.Add(instituicao);
            db.SaveChanges();
            db.Dispose()
            return instituicao;
        }

        public Instituicao EditInstituicao(Instituicao Instituicao){
            Context db = new Context();

            Instituicao instituicao_aux = db.Instituicao.Find(instituicao.IdInstituicao);
            if(instituicao_aux == null)
                return null;
            if(instituicao.IdMatriz != IdMatriz && Instituicao.IsMatriz)
                return null;
            else if(Instituicao.IdMatriz != IdMatriz && Instituicao.IdInstituicao != IdMatriz)
                return null;
            db.Entry(instituicao).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            db.Dispose()
            return instituicao;
        }

        public bool DeleteInstituicao(int? id){
            if(id == null) return false;
            Context db = new Context();
            Instituicao instituicao = db.Instituicao.Find(id);
            if(instituicao == null) return false;
            if(instituicao.IdInstituicao == IdMatriz || instituicao.IdMatriz != IdMatriz) return false;
            db.Instituicao.Remove(instituicao);
            db.SaveChanges();
            db.Dispose();
            return true;
        }
    }
}