using System.Collections.Generic;
using System.Linq;
using System.Web;

using TaCertoForms.Contexts;
using TaCertoForms.Models;

namespace TaCertoForms.Factory {
    public class TurmaAlunoMatrizCreator : BaseCreator, IFactoryTurmaAluno {

        public TurmaAlunoMatrizCreator(HttpSessionStateBase session) : base(session) { }

        public TurmaAluno FindTurmaAluno(int? id) {
            if(id == null) return null;
            Context db = new Context();

            TurmaAluno turmaAluno = db.TurmaAluno.Find(id);
            if(turmaAluno == null) return null;

            Pessoa aluno = db.Pessoa.Find(turmaAluno.IdPessoa);
            if(aluno == null) return null;

            Instituicao instituicao = db.Instituicao.Find(aluno.IdInstituicao);
            if(instituicao == null || (instituicao.IdInstituicao != IdMatriz && instituicao.IdMatriz != IdMatriz)) return null;

            return turmaAluno;
        }

        public List<TurmaAluno> TurmaAlunoList() {
            Context db = new Context();
            List<int> idAuxList;

            List<Instituicao> instituicaoList = db.Instituicao.Where(i => i.IdInstituicao == IdMatriz || i.IdMatriz == IdMatriz).ToList();
            if(instituicaoList == null || instituicaoList.Count == 0) return null;
            idAuxList = new List<int>();
            foreach(var i in instituicaoList) idAuxList.Add(i.IdInstituicao);

            List<Turma> turmaList = db.Turma.Where(t => idAuxList.Contains(t.IdInstituicao)).ToList();
            if(turmaList == null || turmaList.Count == 0) return null;
            idAuxList = new List<int>();
            foreach(var t in turmaList) idAuxList.Add(t.IdTurma);

            List<TurmaAluno> turmaAlunoList = db.TurmaAluno.Where(ta => idAuxList.Contains(ta.IdTurma)).ToList();
            if(turmaAlunoList == null || turmaAlunoList.Count == 0) return null;

            return turmaAlunoList;
        }

        public TurmaAluno CreateTurmaAluno(TurmaAluno turmaAluno) {
            Context db = new Context();

            TurmaAluno ta = db.TurmaAluno.Where(x => x.IdTurma == turmaAluno.IdTurma && x.IdPessoa == turmaAluno.IdPessoa).FirstOrDefault();
            if (ta != null) return null;

            Turma turma = db.Turma.Find(turmaAluno.IdTurma);
            if(turma == null) return null;

            Instituicao instituicao = db.Instituicao.Find(turma.IdInstituicao);
            if(instituicao == null) return null;
            if(instituicao.IdInstituicao != IdMatriz && (instituicao.IdMatriz == null || instituicao.IdMatriz != IdMatriz))
                return null;

            db.TurmaAluno.Add(turmaAluno);
            db.SaveChanges();
            db.Dispose();
            return turmaAluno;
        }

        public TurmaAluno EditTurmaAluno(TurmaAluno turmaAluno) {
            Context db = new Context();

            TurmaAluno turmaAluno_aux = db.TurmaAluno.Find(turmaAluno.IdTurmaAluno);
            if(turmaAluno_aux == null) return null;
            if(turmaAluno_aux.IdTurmaAluno != turmaAluno.IdTurmaAluno) {
                Turma turma = db.Turma.Find(turmaAluno.IdTurma);
                if(turma == null) return null;

                Instituicao instituicao_aux = db.Instituicao.Find(turma.IdInstituicao);
                if(instituicao_aux.IdInstituicao != IdMatriz && (instituicao_aux.IdMatriz == null || instituicao_aux.IdMatriz != IdMatriz))
                    return null;
            }
            if(turmaAluno_aux.IdPessoa != turmaAluno.IdPessoa) {
                Pessoa pessoa = db.Pessoa.Find(turmaAluno.IdPessoa);
                if(pessoa == null) return null;

                Instituicao instituicao_aux = db.Instituicao.Find(pessoa.IdInstituicao);
                if(instituicao_aux.IdInstituicao != IdMatriz && (instituicao_aux.IdMatriz == null || instituicao_aux.IdMatriz != IdMatriz))
                    return null;
            }

            db.Dispose();
            db = new Context();
            db.Entry(turmaAluno).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            db.Dispose();

            return turmaAluno;
        }

        public bool DeleteTurmaAluno(int? id){
            if (id == null) return false;
            Context db = new Context();
            TurmaAluno ta = db.TurmaAluno.Find(id);
            if (ta == null) return false;
                                    
            Turma turma = db.Turma.Find(ta.IdTurma);
            if (turma == null) return false;

            Instituicao instituicao = db.Instituicao.Find(turma.IdInstituicao);
            if (instituicao == null || (instituicao.IdInstituicao != IdMatriz && instituicao.IdMatriz != IdMatriz)) return false;

            db.TurmaAluno.Remove(ta);
            db.SaveChanges();
            db.Dispose();
            return true;
        }
    }
}