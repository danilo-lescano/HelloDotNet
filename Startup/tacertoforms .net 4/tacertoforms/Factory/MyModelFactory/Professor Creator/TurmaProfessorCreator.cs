using System.Linq;
using System.Collections.Generic;
using TaCertoForms.Models;
using TaCertoForms.Contexts;

namespace TaCertoForms.Factory{
    public class TurmaProfessorCreator : BaseCreator, IFactoryTurma{
        public TurmaProfessorCreator(int IdMatriz, int IdPessoa) : base(IdMatriz, IdPessoa) { }

        public Turma FindTurma(int? id){
            if(id == null) return null;
            Context db = new Context();
            List<int> idAuxList;

            List<Instituicao> instituicaoList = db.Instituicao.Where(i => i.IdMatriz == IdMatriz || i.IdIstituicao == IdMatriz).ToList();
            if(instituicaoList == null || instituicaoList.Count == 0) return null;
            idAuxList = new List<int>();
            foreach(var i in instituicaoList) idAuxList.Add(i.IdInstituicao);
            
            Turma turma = db.Turma.Where(t => t.IdTurma == id && idAuxList.Contains(t.IdInstituicao)).FirstOrDefault();
            if(turma == null) return null;

            List<DisciplinaTuma> disciplinaTumaList = db.DisciplinaTuma.Where(dt => dt.IdTurma == turma.IdTurma).ToList();
            if(disciplinaTumaList == null || disciplinaTumaList.Count == 0) return null;
            idAuxList = new List<int>();
            foreach(var dt in disciplinaTumaList) idAuxList.Add(dt.IdDisciplinaTurma);

            List<TurmaDisciplinaAutor> turmaDisciplinaAutorList = db.TurmaDisciplinaAutor.Where(tda => tda.IdAutor == IdPessoa && idAuxList.Contains(tda.IdDisciplinaTurma)).ToList();
            if(turmaDisciplinaAutorList == null || turmaDisciplinaAutorList.Count == 0) return null;
            
            return turma;
        }

        public List<Turma> TurmaList(){
            Context db = new Context();
            List<int> idAuxList;

            List<Instituicao> instituicaoList = db.Instituicao.Where(i => i.IdMatriz == IdMatriz || i.IdInstituicao == IdMatriz).ToList();
            if(instituicaoList == null || instituicaoList.Count == 0) return null;
            idAuxList = new List<int>();
            foreach(var i in instituicaoList) idAuxList.Add(i.IdInstituicao);
            
            List<Turma> turmaList = db.Turma.Where(t => idAuxList.Contains(t.IdInstituicao)).ToList();
            if(turmaList == null) return null;
            idAuxList = new List<int>();
            foreach(var i in instituicaoList) idAuxList.Add(i.IdTurma);

            List<DisciplinaTuma> disciplinaTumaList = db.DisciplinaTuma.Where(dt => idAuxList.Contains(dt.IdTurma)).ToList();
            if(disciplinaTumaList == null || disciplinaTumaList.Count == 0) return null;
            idAuxList = new List<int>();
            foreach(var dt in disciplinaTumaList) idAuxList.Add(dt.IdDisciplinaTurma);

            List<TurmaDisciplinaAutor> turmaDisciplinaAutorList = db.TurmaDisciplinaAutor.Where(tda => tda.IdAutor == IdPessoa && idAuxList.Contains(tda.IdDisciplinaTurma)).ToList();
            if(turmaDisciplinaAutorList == null || turmaDisciplinaAutorList.Count == 0) return null;
            
            return turmaList;
        }

        public Turma CreateTurma(Turma turma){
            throw new System.NotImplementedException();
        }

        public Turma FindTurma(int? id){
            Context db = new Context();

            Pessoa pessoa = db.Pessoa.Find(IdPessoa);
            Turma turma = db.Turma.Find(id);
            if (pessoa == null || turma == null) return null;

            List<int> idAuxList = new List<int>();
            List<TurmaDisciplinaAutor> turmaDisciplinaAutorList = db.TurmaDisciplinaAutor.Where(tda => tda.IdAutor == pessoa.IdPessoa).ToList();
            if (turmaDisciplinaAutorList == null || turmaDisciplinaAutorList.Count == 0) return null;
            foreach (var tda in turmaDisciplinaAutorList) idAuxList.Add(tda.IdDisciplinaTurma);            

            db.Dispose();
            if (idAuxList.Contains(turma.IdTurma)) return turma;
            return null;
        }

        public List<Turma> TurmaList(){
            Context db = new Context();

            Pessoa pessoa = db.Pessoa.Find(IdPessoa);
            if (pessoa == null) return null;

            List<int> idAuxList = new List<int>();
            List<TurmaDisciplinaAutor> turmaDisciplinaAutorList = db.TurmaDisciplinaAutor.Where(tda => tda.IdAutor == pessoa.IdPessoa).ToList();
            if (turmaDisciplinaAutorList == null || turmaDisciplinaAutorList.Count == 0) return null;
            foreach (var tda in turmaDisciplinaAutorList) idAuxList.Add(tda.IdDisciplinaTurma);
                        
            List<Turma> turmas = db.Turma.Where(a => idAuxList.Contains(a.IdTurma)).ToList();
            if (turmas == null || turmas.Count == 0) return null;           

            db.Dispose();
            return turmas;
        }
    }
}