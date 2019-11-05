using System.Web;
using System.Linq;
using System.Collections.Generic;
using TaCertoForms.Models;
using TaCertoForms.Contexts;

namespace TaCertoForms.Factory{
    public class TurmaMatrizCreator : BaseCreator, IFactoryTurma{

        public TurmaMatrizCreator(HttpSessionStateBase session) : base(session) { }

        public Turma FindTurma(int? id){
            if (id == null) return null;
            Context db = new Context();

            Turma turma = db.Turma.Find(id);
            if(turma == null) return null;

            Instituicao instituicao = db.Instituicao.Find(turma.IdInstituicao);
            if(instituicao == null) return null;

            if (instituicao.IdInstituicao != IdMatriz && (instituicao.IdMatriz == null || instituicao.IdMatriz != IdMatriz))
                return null;
            db.Dispose();
            return turma;
        }

        public List<Turma> TurmaList(){
            Context db = new Context();
            List<int> idAuxList;

            List<Instituicao> instituicaoList = db.Instituicao.Where(i => i.IdInstituicao == IdMatriz || (i.IdMatriz != null && i.IdMatriz == IdMatriz)).ToList();
            if(instituicaoList == null || instituicaoList.Count == 0) return null;
            idAuxList = new List<int>();
            foreach(var i in instituicaoList) idAuxList.Add(i.IdInstituicao);
            
            List<Turma> turmaList;
            turmaList = db.Turma.Where(t => idAuxList.Contains(t.IdInstituicao)).ToList();

            if(turmaList == null || turmaList.Count == 0) return null;

            db.Dispose();
            return turmaList;
        }

        public Turma CreateTurma(Turma turma){
            Context db = new Context();

            Instituicao instituicao = db.Instituicao.Find(turma.IdInstituicao);
            if(instituicao == null) return null;
            if (instituicao.IdInstituicao != IdMatriz && (instituicao.IdMatriz == null || instituicao.IdMatriz != IdMatriz))
                return null;

            db.Turma.Add(turma);
            db.SaveChanges();
            db.Dispose();
            return turma;
        }

        public Turma EditTurma(Turma turma){
            //TODO Como será se após vinculado turma com aluno e disciplina, o usuário mudasse a turma?
            Context db = new Context();

            Turma turma_aux = db.Turma.Find(turma.IdTurma);
            if(turma_aux == null) return null;
            if(turma_aux.IdInstituicao != turma.IdInstituicao){
                Instituicao instituicao_aux = db.Instituicao.Find(turma_aux.IdInstituicao);
                if (instituicao_aux.IdInstituicao != IdMatriz && (instituicao_aux.IdMatriz == null || instituicao_aux.IdMatriz != IdMatriz))
                    return null;
            }

            Instituicao instituicao = db.Instituicao.Find(turma.IdInstituicao);
            if (instituicao.IdInstituicao != IdMatriz && (instituicao.IdMatriz == null || instituicao.IdMatriz != IdMatriz))
                    return null;

            db.Entry(turma).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            db.Dispose();

            return turma;
        }

        public bool DeleteTurma(int? id){
            throw new System.NotImplementedException();
        }
    }
}