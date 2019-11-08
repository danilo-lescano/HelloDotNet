using System.Collections.Generic;
using System.Linq;
using System.Web;

using TaCertoForms.Contexts;
using TaCertoForms.Models;

namespace TaCertoForms.Factory {
    //CLASSE InstituicaoMatrizCreator - Responsavel por pegar no banco de dados apenas as Instituicoes relacionadas a uma determinada matriz
    public class InstituicaoMatrizCreator : BaseCreator, IFactoryInstituicao {
        public InstituicaoMatrizCreator(HttpSessionStateBase session) : base(session) { }

        public Instituicao FindInstituicao(int? id) {
            if(id == null) return null;
            Context db = new Context();
            Instituicao instituicao = db.Instituicao.Find(id);
            if(instituicao == null) return null;
            if(instituicao.IdInstituicao == IdMatriz || (instituicao.IdMatriz != null && instituicao.IdMatriz == IdMatriz))
                return instituicao;
            db.Dispose();
            return null;
        }

        public List<Instituicao> InstituicaoList() {
            Context db = new Context();
            List<Instituicao> instituicaoList = db.Instituicao.Where(i => i.IdInstituicao == IdMatriz || (i.IdMatriz != null && i.IdMatriz == IdMatriz)).ToList();
            if(instituicaoList == null || instituicaoList.Count == 0) return null;
            db.Dispose();
            return instituicaoList;
        }

        public Instituicao CreateInstituicao(Instituicao instituicao) {
            Context db = new Context();
            Instituicao instituicao_aux = db.Instituicao.Find(instituicao.IdInstituicao);
            if(instituicao_aux != null)
                return null;
            instituicao.IdMatriz = IdMatriz;
            instituicao.IsMatriz = false;
            db.Instituicao.Add(instituicao);
            db.SaveChanges();
            db.Dispose();
            return instituicao;
        }

        public Instituicao EditInstituicao(Instituicao instituicao) {
            Context db = new Context();
            Instituicao instituicao_aux = db.Instituicao.Find(instituicao.IdInstituicao);
            if(instituicao_aux == null)
                return null;
            instituicao.IdMatriz = instituicao_aux.IdMatriz;
            instituicao.IsMatriz = instituicao_aux.IsMatriz;
            if(instituicao.IdMatriz != IdMatriz && instituicao.IdInstituicao != IdMatriz)
                return null;
            db.Dispose();
            db = new Context();
            db.Entry(instituicao).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            db.Dispose();
            return instituicao;
        }

        public bool DeleteInstituicao(int? id) {
            //##### Para essa primeira versão, não será implementado a funcionalide de exclusão de instituição.
            return false;
            /*             
            if(id == null) return false;
            Context db = new Context();
            Instituicao instituicao = db.Instituicao.Find(id);
            if(instituicao == null) return false;
            if(instituicao.IdInstituicao == IdMatriz || instituicao.IdMatriz != IdMatriz) return false;
            db.Instituicao.Remove(instituicao);
            db.SaveChanges();
            db.Dispose();
            return true;
            */
        }
    }
}