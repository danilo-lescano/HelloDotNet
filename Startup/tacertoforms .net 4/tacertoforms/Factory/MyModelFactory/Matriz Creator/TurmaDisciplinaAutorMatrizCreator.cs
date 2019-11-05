using System.Web;
using System.Linq;
using System.Collections.Generic;
using TaCertoForms.Models;
using TaCertoForms.Contexts;

namespace TaCertoForms.Factory{
    public class TurmaDisciplinaAutorMatrizCreator : BaseCreator, IFactoryTurmaDisciplinaAutor{

        public TurmaDisciplinaAutorMatrizCreator(HttpSessionStateBase session) : base(session) { }

        public TurmaDisciplinaAutor FindTurmaDisciplinaAutor(int? id){
            if (id == null) return null;
            Context db = new Context();

            TurmaDisciplinaAutor turmaDisciplinaAutor = db.TurmaDisciplinaAutor.Find(id);
            if(turmaDisciplinaAutor == null) return null;

            DisciplinaTurma disciplinaTurma = db.DisciplinaTurma.Find(turmaDisciplinaAutor.IdDisciplinaTurma);
            if(disciplinaTurma == null) return null;
            
            Turma turma = db.Turma.Find(disciplinaTurma.IdTurma);
            if(turma == null) return null;

            Instituicao instituicao = db.Instituicao.Find(turma.IdInstituicao);
            if(instituicao == null) return null;

            if (instituicao.IdInstituicao != IdMatriz && (instituicao.IdMatriz == null || instituicao.IdMatriz != IdMatriz))
                return null;

            db.Dispose();
            return turmaDisciplinaAutor;
        }

        public List<TurmaDisciplinaAutor> TurmaDisciplinaAutorList(){
            Context db = new Context();
            List<int> idAuxList;

            List<Instituicao> instituicaoList = db.Instituicao.Where(i => i.IdInstituicao == IdMatriz || (i.IdMatriz != null && i.IdMatriz == IdMatriz)).ToList();
            if(instituicaoList == null || instituicaoList.Count == 0) return null;
            idAuxList = new List<int>();
            foreach(var i in instituicaoList) idAuxList.Add(i.IdInstituicao);
            
            List<Turma> turmaList = db.Turma.Where(t => idAuxList.Contains(t.IdInstituicao)).ToList();
            if(turmaList == null || turmaList.Count == 0) return null;
            idAuxList = new List<int>();
            foreach(var t in turmaList) idAuxList.Add(t.IdTurma);

            List<DisciplinaTurma> disciplinaTurmaList = db.DisciplinaTurma.Where(dt => idAuxList.Contains(dt.IdTurma)).ToList();
            if(disciplinaTurmaList == null || disciplinaTurmaList.Count == 0) return null;
            idAuxList = new List<int>();
            foreach(var dt in disciplinaTurmaList) idAuxList.Add(dt.IdDisciplinaTurma);

            List<TurmaDisciplinaAutor> turmadisciplinaAutorList = db.TurmaDisciplinaAutor.Where(tda => idAuxList.Contains(tda.IdDisciplinaTurma)).ToList();
            if(turmadisciplinaAutorList == null || turmadisciplinaAutorList.Count == 0) return null;

            db.Dispose();
            return turmadisciplinaAutorList;
        }

        public TurmaDisciplinaAutor CreateTurmaDisciplinaAutor(TurmaDisciplinaAutor turmaDisciplinaAutor){
            Context db = new Context();


            DisciplinaTurma disciplinaTurma = db.DisciplinaTurma.Find(turmaDisciplinaAutor.IdDisciplinaTurma);
            if(disciplinaTurma == null) return null;

            Turma turma = db.Turma.Find(disciplinaTurma.IdTurma);
            if(turma == null) return null;

            Instituicao instituicao = db.Instituicao.Find(turma.IdInstituicao);
            if(instituicao == null) return null;
            if (instituicao.IdInstituicao != IdMatriz && (instituicao.IdMatriz == null || instituicao.IdMatriz != IdMatriz))
                return null;

            db.TurmaDisciplinaAutor.Add(turmaDisciplinaAutor);
            db.SaveChanges();
            db.Dispose();
            return turmaDisciplinaAutor;
        }

        public TurmaDisciplinaAutor EditTurmaDisciplinaAutor(TurmaDisciplinaAutor turmaDisciplinaAutor){
            Context db = new Context();

            TurmaDisciplinaAutor turmaDisciplinaAutor_aux = db.TurmaDisciplinaAutor.Find(turmaDisciplinaAutor.IdTurmaDisciplinaAutor);

            DisciplinaTurma disciplinaTurma = db.DisciplinaTurma.Find(turmaDisciplinaAutor.IdDisciplinaTurma);
            if(disciplinaTurma == null) return null;

            DisciplinaTurma disciplinaTurma_aux = db.DisciplinaTurma.Find(turmaDisciplinaAutor_aux.IdDisciplinaTurma);
            if(disciplinaTurma_aux == null) return null;

            if(disciplinaTurma_aux.IdTurma != disciplinaTurma.IdTurma){
                Turma turma_aux = db.Turma.Find(disciplinaTurma_aux.IdTurma);
                if(turma_aux == null) return null;

                Instituicao instituicao_aux = db.Instituicao.Find(turma_aux.IdInstituicao);
                if(instituicao_aux.IdInstituicao != IdMatriz && (instituicao_aux.IdMatriz == null || instituicao_aux.IdMatriz != IdMatriz)) return null;
            }

            if(disciplinaTurma_aux.IdDisciplina != disciplinaTurma.IdDisciplina){
                Disciplina disciplina_aux = db.Disciplina.Find(disciplinaTurma_aux.IdDisciplina);
                if(disciplina_aux == null) return null;
                if(disciplina_aux.IdMatriz != IdMatriz) return null;
            }

            db.Dispose();
            db = new Context();
            db.Entry(turmaDisciplinaAutor).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            db.Dispose();

            return turmaDisciplinaAutor;
        }

        public bool DeleteTurmaDisciplinaAutor(int? id){
            if(id == null) return false;
            Context db = new Context();

            TurmaDisciplinaAutor turmaDisciplinaAutor = db.TurmaDisciplinaAutor.Find(id);
            if(turmaDisciplinaAutor == null) return false;

            DisciplinaTurma disciplinaTurma = db.DisciplinaTurma.Find(turmaDisciplinaAutor.IdDisciplinaTurma);
            if(disciplinaTurma == null) return false;

            Turma turma = db.Turma.Find(disciplinaTurma.IdTurma);
            if(turma == null) return false;

            Instituicao instituicao = db.Instituicao.Find(turma.IdInstituicao);
            if(instituicao == null || (instituicao.IdInstituicao != IdMatriz && instituicao.IdMatriz != IdMatriz)) return false;

            db.TurmaDisciplinaAutor.Remove(turmaDisciplinaAutor);
            db.SaveChanges();
            db.Dispose();
            return true;
        }
    }
}