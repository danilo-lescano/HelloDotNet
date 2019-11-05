using System.Web;
using System.Linq;
using System.Collections.Generic;
using TaCertoForms.Models;
using TaCertoForms.Contexts;

namespace TaCertoForms.Factory{
    //CLASSE QuestaoProfessorCreator - Responsavel por pegar no banco de dados apenas as Questaos relacionadas a uma determinada matriz
    public class QuestaoProfessorCreator : BaseCreator, IFactoryQuestao{
        public QuestaoProfessorCreator(HttpSessionStateBase session) : base(session) {}

        public Questao CreateQuestao(Questao questao){
            Context db = new Context();

            Pessoa pessoa = db.Pessoa.Find(IdPessoa);
            Questao questaoBanco = db.Questao.Find(questao.IdQuestao);
            if (pessoa == null) return null;
            if (questaoBanco != null) return questaoBanco;

            List<int> idAuxList = new List<int>();
            List<TurmaDisciplinaAutor> turmaDisciplinaAutorList = db.TurmaDisciplinaAutor.Where(tda => tda.IdAutor == pessoa.IdPessoa).ToList();
            if (turmaDisciplinaAutorList == null || turmaDisciplinaAutorList.Count == 0) return null;
            foreach (var tda in turmaDisciplinaAutorList) idAuxList.Add(tda.IdTurmaDisciplinaAutor);

            List<Atividade> atividadeList = db.Atividade.Where(at => idAuxList.Contains(at.IdTurmaDisciplinaAutor)).ToList();
            if (atividadeList == null || atividadeList.Count == 0) return null;
            idAuxList = new List<int>();
            foreach (var at in atividadeList) idAuxList.Add(at.IdAtividade);

            if (idAuxList.Contains(questao.IdAtividade)) {
                db.Questao.Add(questao);
                db.SaveChanges();
                db.Dispose();
                return questao;
            }
            return null;           
        }

        public bool DeleteQuestao(int? id){
            Context db = new Context();

            Pessoa pessoa = db.Pessoa.Find(IdPessoa);
            Questao questao = db.Questao.Find(id);
            if (pessoa == null || questao == null) return false;

            List<int> idAuxList = new List<int>();
            List<TurmaDisciplinaAutor> turmaDisciplinaAutorList = db.TurmaDisciplinaAutor.Where(tda => tda.IdAutor == pessoa.IdPessoa).ToList();
            if (turmaDisciplinaAutorList == null || turmaDisciplinaAutorList.Count == 0) return false;
            foreach (var tda in turmaDisciplinaAutorList) idAuxList.Add(tda.IdDisciplinaTurma);

            List<Atividade> atividadeList = db.Atividade.Where(at => idAuxList.Contains(at.IdTurmaDisciplinaAutor)).ToList();
            if (atividadeList == null || atividadeList.Count == 0) return false;
            idAuxList = new List<int>();
            foreach (var at in atividadeList) idAuxList.Add(at.IdAtividade);

            if (idAuxList.Contains(questao.IdAtividade))
            {
                db.Questao.Remove(questao);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public Questao EditQuestao(Questao questao){
            Context db = new Context();

            Pessoa pessoa = db.Pessoa.Find(IdPessoa);
            Questao questaoBanco = db.Questao.Find(questao.IdQuestao);
            if (pessoa == null || questaoBanco == null) return null;            

            List<int> idAuxList = new List<int>();
            List<TurmaDisciplinaAutor> turmaDisciplinaAutorList = db.TurmaDisciplinaAutor.Where(tda => tda.IdAutor == pessoa.IdPessoa).ToList();
            if (turmaDisciplinaAutorList == null || turmaDisciplinaAutorList.Count == 0) return null;
            foreach (var tda in turmaDisciplinaAutorList) idAuxList.Add(tda.IdDisciplinaTurma);

            List<Atividade> atividadeList = db.Atividade.Where(at => idAuxList.Contains(at.IdTurmaDisciplinaAutor)).ToList();
            if (atividadeList == null || atividadeList.Count == 0) return null;
            idAuxList = new List<int>();
            foreach (var at in atividadeList) idAuxList.Add(at.IdAtividade);

            if (idAuxList.Contains(questao.IdAtividade))
            {                
                db.Entry(questao).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                db.Dispose();
                return questao;
            }
            return null;
        }

        public Questao FindQuestao(int? id){
            Context db = new Context();

            Pessoa pessoa = db.Pessoa.Find(IdPessoa);
            Questao questao = db.Questao.Find(id);
            if (pessoa == null || questao == null) return null;

            List<int> idAuxList = new List<int>();
            List<TurmaDisciplinaAutor> turmaDisciplinaAutorList = db.TurmaDisciplinaAutor.Where(tda => tda.IdAutor == pessoa.IdPessoa).ToList();
            if (turmaDisciplinaAutorList == null || turmaDisciplinaAutorList.Count == 0) return null;
            foreach (var tda in turmaDisciplinaAutorList) idAuxList.Add(tda.IdDisciplinaTurma);

            List<Atividade> atividadeList = db.Atividade.Where(at => idAuxList.Contains(at.IdTurmaDisciplinaAutor)).ToList();
            if (atividadeList == null || atividadeList.Count == 0) return null;
            idAuxList = new List<int>();
            foreach (var at in atividadeList) idAuxList.Add(at.IdAtividade);

            db.Dispose();
            if (idAuxList.Contains(questao.IdAtividade)) return questao;           
            return null;
        }

        public List<Questao> FindQuestaoByTypeAndActivity(int? idAtividade, int? idTipoQuestao){
            Context db = new Context();

            Pessoa pessoa = db.Pessoa.Find(IdPessoa);
            if (pessoa == null || (idAtividade == null && idTipoQuestao == null)) return null;

            List<int> idAuxList = new List<int>();
            List<TurmaDisciplinaAutor> turmaDisciplinaAutorList = db.TurmaDisciplinaAutor.Where(tda => tda.IdAutor == pessoa.IdPessoa).ToList();
            if (turmaDisciplinaAutorList == null || turmaDisciplinaAutorList.Count == 0) return null;
            foreach (var tda in turmaDisciplinaAutorList) idAuxList.Add(tda.IdTurmaDisciplinaAutor);

            List<Atividade> atividadeList = db.Atividade.Where(at => idAuxList.Contains(at.IdTurmaDisciplinaAutor)).ToList();
            if (atividadeList == null || atividadeList.Count == 0) return null;
            idAuxList = new List<int>();
            foreach (var at in atividadeList) idAuxList.Add(at.IdAtividade);
                        
            if (idAtividade != null && idAuxList.Contains((int)idAtividade)) {
                return db.Questao.Where(q => q.IdAtividade == idAtividade).ToList();
            } else if (idTipoQuestao != null) {
                return db.Questao.Where(q => q.IdTipoQuestao == idTipoQuestao && idAuxList.Contains(q.IdAtividade)).ToList();
            } else if (idAtividade != null && idAuxList.Contains((int)idAtividade) && idTipoQuestao != null) {
                return db.Questao.Where(q => q.IdAtividade == idAtividade && q.IdTipoQuestao == idTipoQuestao).ToList();
            }
            return null;
        }

        public List<Questao> QuestaoList(){
            throw new System.NotImplementedException();
        }
    }
}