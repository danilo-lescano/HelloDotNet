using System.Linq;
using System.Collections.Generic;
using TaCertoForms.Models;
using TaCertoForms.Contexts;

namespace TaCertoForms.Factory{
    //CLASSE QuestaoMatrizCreator - Responsavel por pegar no banco de dados apenas as Questaos relacionadas a uma determinada matriz
    public class QuestaoMatrizCreator : BaseCreator, IFactoryQuestao{
        public QuestaoMatrizCreator(int IdMatriz, int IdPessoa) : base(IdMatriz,IdPessoa) {}

        public Questao FindQuestao(int? id){
            if(id == null) return null;
            Context db = new Context();
            Questao questao = db.Questao.Find(id);
            if(questao == null) return null;

            Atividade atividade = db.Atividade.Find(questao.IdAtividade);
            if(atividade == null) return null;

            TurmaDisciplinaAutor turmaDisciplinaAutor = db.TurmaDisciplinaAutor.Find(atividade.IdTurmaDisciplinaAutor);
            if(turmaDisciplinaAutor == null) return null;

            Pessoa autor = db.Pessoa.Find(turmaDisciplinaAutor.IdAutor);
            if(autor == null) return null;

            Instituicao instituicao = db.Instituicao.Find(autor.IdInstituicao);
            if(instituicao == null) return null;
            if(instituicao.IdInstituicao == IdMatriz || (instituicao.IdMatriz != null && instituicao.IdMatriz == IdMatriz))
                return questao;

            db.Dispose();
            return null;
        }
        public List<Questao> QuestaoList(){
            Context db = new Context();
            List<int> idAuxList;
            
            List<Instituicao> instituicaoList = db.Instituicao.Where(i => i.IdInstituicao == IdMatriz || (i.IdMatriz != null && i.IdMatriz == IdMatriz)).ToList();
            if(instituicaoList == null || instituicaoList.Count == 0) return null;
            idAuxList = new List<int>();
            foreach (var i in instituicaoList) idAuxList.Add(i.IdInstituicao);

            List<Pessoa> pessoaList = db.Pessoa.Where(p => idAuxList.Contains(p.IdInstituicao)).ToList();
            if(pessoaList == null || pessoaList.Count == 0) return null;
            idAuxList = new List<int>();
            foreach (var p in pessoaList) idAuxList.Add(p.IdPessoa);

            List<TurmaDisciplinaAutor> turmaDisciplinaAutorList = db.TurmaDisciplinaAutor.Where(tda => idAuxList.Contains(tda.IdAutor)).ToList();
            if(turmaDisciplinaAutorList == null || turmaDisciplinaAutorList.Count == 0) return null;
            idAuxList = new List<int>();
            foreach (var tda in turmaDisciplinaAutorList) idAuxList.Add(tda.IdTurmaDisciplinaAutor);

            List<Atividade> atividadeList = db.Atividade.Where(a => idAuxList.Contains(a.IdTurmaDisciplinaAutor)).ToList();
            if(atividadeList == null || atividadeList.Count == 0) return null;
            idAuxList = new List<int>();
            foreach (var a in atividadeList) idAuxList.Add(a.IdAtividade);

            List<Questao> questaoList = db.Questao.Where(a => idAuxList.Contains(a.IdAtividade)).ToList();
            if(questaoList == null || questaoList.Count == 0) return null;

            db.Dispose();
            return questaoList;
        }

        public Questao CreateQuestao(Questao atividade){
            throw new System.NotImplementedException();
        }

        public Questao EditQuestao(Questao atividade){
            throw new System.NotImplementedException();
        }

        public bool DeleteQuestao(int? id){
            throw new System.NotImplementedException();
        }

        public List<Questao> FindQuestaoByTypeAndActivity(int? idAtividade, int? idTipoQuestao)
        {
            throw new System.NotImplementedException();
        }
    }
}