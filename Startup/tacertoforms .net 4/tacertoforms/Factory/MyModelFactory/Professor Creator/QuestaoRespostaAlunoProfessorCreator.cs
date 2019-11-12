using System.Collections.Generic;
using System.Linq;
using System.Web;

using TaCertoForms.Contexts;
using TaCertoForms.Models;

namespace TaCertoForms.Factory {
    //CLASSE QuestaoRespostaAlunoProfessorCreator - Responsavel por pegar no banco de dados apenas as QuestaoRespostaAlunos relacionadas a uma determinada matriz
    public class QuestaoRespostaAlunoProfessorCreator : BaseCreator, IFactoryQuestaoRespostaAluno {
        public QuestaoRespostaAlunoProfessorCreator(HttpSessionStateBase session) : base(session) { }

        public QuestaoRespostaAluno CreateQuestaoRespostaAluno(QuestaoRespostaAluno questaoRespostaAluno) {
            throw new System.NotImplementedException();
        }

        public bool DeleteQuestaoRespostaAluno(int? id) {
            Context db = new Context();

            QuestaoRespostaAluno questaoRespostaAluno = db.QuestaoRespostaAluno.Find(id);
            if(questaoRespostaAluno == null) return false;

            Pessoa pessoa = db.Pessoa.Find(IdPessoa);
            Questao questao = db.Questao.Find(questaoRespostaAluno.IdQuestao);
            if(pessoa == null || questao == null) return false;

            List<int> idAuxList = new List<int>();
            List<TurmaDisciplinaAutor> turmaDisciplinaAutorList = db.TurmaDisciplinaAutor.Where(tda => tda.IdAutor == pessoa.IdPessoa).ToList();
            if(turmaDisciplinaAutorList == null || turmaDisciplinaAutorList.Count == 0) return false;
            foreach(var tda in turmaDisciplinaAutorList) idAuxList.Add(tda.IdTurmaDisciplinaAutor);

            List<Atividade> atividadeList = db.Atividade.Where(at => idAuxList.Contains(at.IdTurmaDisciplinaAutor)).ToList();
            if(atividadeList == null || atividadeList.Count == 0) return false;
            idAuxList = new List<int>();
            foreach(var at in atividadeList) idAuxList.Add(at.IdAtividade);

            if(idAuxList.Contains(questao.IdAtividade)) {
                db.QuestaoRespostaAluno.Remove(questaoRespostaAluno);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public QuestaoRespostaAluno EditQuestaoRespostaAluno(QuestaoRespostaAluno questaoRespostaAluno) {
            throw new System.NotImplementedException();
        }

        public QuestaoRespostaAluno FindQuestaoRespostaAluno(int? id) {
            throw new System.NotImplementedException();
        }

        public List<QuestaoRespostaAluno> FindQuestaoRespostaAlunoByQuestao(int? idQuestao) {
            Context db = new Context();

            Pessoa pessoa = db.Pessoa.Find(IdPessoa);
            List<QuestaoRespostaAluno> questaoRespostaAluno = db.QuestaoRespostaAluno.Where(x => x.IdQuestao == idQuestao).ToList();
            if (pessoa == null || questaoRespostaAluno == null || questaoRespostaAluno.Count == 0) return null;

            List<int> idAuxList = new List<int>();
            List<TurmaDisciplinaAutor> turmaDisciplinaAutorList = db.TurmaDisciplinaAutor.Where(tda => tda.IdAutor == pessoa.IdPessoa).ToList();
            if (turmaDisciplinaAutorList == null || turmaDisciplinaAutorList.Count == 0) return null;
            foreach (var tda in turmaDisciplinaAutorList) idAuxList.Add(tda.IdTurmaDisciplinaAutor);

            List<Atividade> atividadeList = db.Atividade.Where(dt => idAuxList.Contains(dt.IdTurmaDisciplinaAutor)).ToList();
            if (atividadeList == null || atividadeList.Count == 0) return null;
            idAuxList = new List<int>();
            foreach (var at in atividadeList) idAuxList.Add(at.IdAtividade);

            List<Questao> questaoList = db.Questao.Where(dt => idAuxList.Contains(dt.IdAtividade)).ToList();
            if (questaoList == null || questaoList.Count == 0) return null;
            idAuxList = new List<int>();
            foreach (var q in questaoList) idAuxList.Add(q.IdQuestao);     

            db.Dispose();
            if (idAuxList.Contains((int)idQuestao)) return questaoRespostaAluno;
            return null;
        }

        public List<QuestaoRespostaAluno> QuestaoRespostaAlunoList() {
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
            idAuxList = new List<int>();
            foreach(var a in atividadeList) idAuxList.Add(a.IdAtividade);

            List<Questao> questaoList = db.Questao.Where(q => idAuxList.Contains(q.IdAtividade)).ToList();
            if(questaoList == null || questaoList.Count == 0) return null;
            idAuxList = new List<int>();
            foreach(var q in questaoList) idAuxList.Add(q.IdQuestao);

            List<QuestaoRespostaAluno> questaoRespostaAlunoList = db.QuestaoRespostaAluno.Where(qra => idAuxList.Contains(qra.IdQuestao)).ToList();
            if(questaoRespostaAlunoList == null || questaoRespostaAlunoList.Count == 0) return null;

            db.Dispose();
            return questaoRespostaAlunoList;
        }
    }
}