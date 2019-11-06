using System.Collections.Generic;
using System.Linq;
using System.Web;

using TaCertoForms.Contexts;
using TaCertoForms.Models;

namespace TaCertoForms.Factory {
    //CLASSE AtividadeMatrizCreator - Responsavel por pegar no banco de dados apenas as Atividades relacionadas a uma determinada matriz
    public class AtividadeMatrizCreator : BaseCreator, IFactoryAtividade {
        public AtividadeMatrizCreator(HttpSessionStateBase session) : base(session) { }

        public Atividade FindAtividade(int? id) {
            if(id == null) return null;
            Context db = new Context();
            Atividade atividade = db.Atividade.Find(id);
            if(atividade == null) return null;
            TurmaDisciplinaAutor turmaDisciplinaAutor = db.TurmaDisciplinaAutor.Find(atividade.IdTurmaDisciplinaAutor);
            if(turmaDisciplinaAutor == null) return null;
            Pessoa autor = db.Pessoa.Find(turmaDisciplinaAutor.IdAutor);
            if(autor == null) return null;
            Instituicao instituicao = db.Instituicao.Find(autor.IdInstituicao);
            if(instituicao == null) return null;
            if(instituicao.IdInstituicao == IdMatriz || (instituicao.IdMatriz != null && instituicao.IdMatriz == IdMatriz))
                return atividade;
            db.Dispose();
            return null;
        }
        public List<Atividade> AtividadeList() {
            Context db = new Context();
            List<int> idAuxList;
            
            List<Instituicao> instituicaoList = db.Instituicao.Where(i => i.IdInstituicao == IdMatriz || (i.IdMatriz != null && i.IdMatriz == IdMatriz)).ToList();
            if(instituicaoList == null || instituicaoList.Count == 0) return null;
            idAuxList = new List<int>();
            foreach(var i in instituicaoList) idAuxList.Add(i.IdInstituicao);

            List<Pessoa> pessoaList = db.Pessoa.Where(p => idAuxList.Contains(p.IdInstituicao)).ToList();
            if(pessoaList == null || pessoaList.Count == 0) return null;
            idAuxList = new List<int>();
            foreach(var p in pessoaList) idAuxList.Add(p.IdPessoa);

            List<TurmaDisciplinaAutor> turmaDisciplinaAutorList = db.TurmaDisciplinaAutor.Where(tda => idAuxList.Contains(tda.IdAutor)).ToList();
            if(turmaDisciplinaAutorList == null || turmaDisciplinaAutorList.Count == 0) return null;
            idAuxList = new List<int>();
            foreach(var tda in turmaDisciplinaAutorList) idAuxList.Add(tda.IdTurmaDisciplinaAutor);

            List<Atividade> atividadeList = db.Atividade.Where(a => idAuxList.Contains(a.IdTurmaDisciplinaAutor)).ToList();
            if(atividadeList == null || atividadeList.Count == 0) return null;

            db.Dispose();
            return atividadeList;
        }

        public Atividade CreateAtividade(Atividade atividade) {
            throw new System.NotImplementedException();
        }

        public Atividade EditAtividade(Atividade atividade) {
            throw new System.NotImplementedException();
        }

        public bool DeleteAtividade(int? id) {
            throw new System.NotImplementedException();
        }
    }
}