using System.Web;
using System.Linq;
using System.Collections.Generic;
using TaCertoForms.Models;
using TaCertoForms.Contexts;

namespace TaCertoForms.Factory{
    //CLASSE AtividadeProfessorCreator - Responsavel por pegar no banco de dados apenas as Atividades relacionadas a uma determinada matriz
    public class AtividadeProfessorCreator : BaseCreator, IFactoryAtividade{
        public AtividadeProfessorCreator(HttpSessionStateBase session) : base(session) {}

        public List<Atividade> AtividadeList(){
            Context db = new Context();
            List<int> idAuxList;

            List<Instituicao> instituicaoList = db.Instituicao.Where(i => i.IdInstituicao == IdMatriz || (i.IdMatriz != null && i.IdMatriz == IdMatriz)).ToList();
            if (instituicaoList == null || instituicaoList.Count == 0) return null;
            idAuxList = new List<int>();
            foreach (var i in instituicaoList) idAuxList.Add(i.IdInstituicao);

            List<Pessoa> pessoaList = db.Pessoa.Where(p => idAuxList.Contains(p.IdInstituicao)).ToList();
            if (pessoaList == null || pessoaList.Count == 0) return null;
            idAuxList = new List<int>();
            foreach (var p in pessoaList) idAuxList.Add(p.IdPessoa);

            List<TurmaDisciplinaAutor> turmaDisciplinaAutorList = db.TurmaDisciplinaAutor.Where(tda => idAuxList.Contains(tda.IdAutor)).ToList();
            if (turmaDisciplinaAutorList == null || turmaDisciplinaAutorList.Count == 0) return null;
            idAuxList = new List<int>();
            foreach (var tda in turmaDisciplinaAutorList) idAuxList.Add(tda.IdTurmaDisciplinaAutor);

            List<Atividade> atividadeList = db.Atividade.Where(a => idAuxList.Contains(a.IdTurmaDisciplinaAutor)).ToList();
            if (atividadeList == null || atividadeList.Count == 0) return null;

            db.Dispose();
            return atividadeList;
        }

        public Atividade CreateAtividade(Atividade atividade){
            Context db = new Context();
            Pessoa pessoa = db.Pessoa.Find(IdPessoa);
            if (pessoa == null) return null;
                        
            List<int> idAuxList = new List<int>();
            List<TurmaDisciplinaAutor> tda = db.TurmaDisciplinaAutor.Where(x => x.IdAutor == pessoa.IdPessoa).ToList();
            if (tda == null || tda.Count == 0) return null;
            foreach (var t in tda) idAuxList.Add(t.IdTurmaDisciplinaAutor);

            if (!idAuxList.Contains(atividade.IdTurmaDisciplinaAutor)) return null;
                        
            db.Atividade.Add(atividade);
            db.SaveChanges();
            db.Dispose();

            return atividade;
        }

        public bool DeleteAtividade(int? id){
            throw new System.NotImplementedException();
        }

        public Atividade EditAtividade(Atividade atividade){
            throw new System.NotImplementedException();
        }

        public Atividade FindAtividade(int? id){
            Context db = new Context();
            List<int> idAuxList;
            Pessoa pessoa = db.Pessoa.Find(IdPessoa);
            Atividade atividade = db.Atividade.Find(id);
            if (pessoa == null || atividade == null) return null;
                                    
            List<TurmaDisciplinaAutor> turmaDisciplinaAutorList = db.TurmaDisciplinaAutor.Where(tda => tda.IdAutor == pessoa.IdPessoa).ToList();
            if (turmaDisciplinaAutorList == null || turmaDisciplinaAutorList.Count == 0) return null;
            idAuxList = new List<int>();
            foreach (var tda in turmaDisciplinaAutorList) idAuxList.Add(tda.IdTurmaDisciplinaAutor);

            db.Dispose();
            if (idAuxList.Contains(atividade.IdTurmaDisciplinaAutor)) return atividade;           
            return null;
        }
    }
}