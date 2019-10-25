using System.Data;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using TaCertoForms.Models;
using TaCertoForms.Contexts;

namespace TaCertoForms.Controllers.Base{
    public class ControladoraBase : Controller{
        protected Context db = new Context();

        protected List<Pessoa> GetMeusAlunos(){
            Context db = new Context();
            List<TurmaAluno> turmaAlunos = new List<TurmaAluno>();
            List<Pessoa> alunos = new List<Pessoa>();
            List<TurmaDisciplinaAutor> tda_aux = db.TurmaDisciplinaAutor.Where(tda => tda.IdAutor == (int)Session["IdPessoa"]).ToList();
            foreach (var tda in tda_aux){
                DisciplinaTurma dt = db.DisciplinaTurma.Find(tda.IdDisciplinaTurma);
                Turma t = db.Turma.Find(dt.IdTurma);
                List<TurmaAluno> ta_aux = db.TurmaAluno.Where(ta => ta.IdTurma == t.IdTurma && !turmaAlunos.Contains(ta)).ToList();
                turmaAlunos = turmaAlunos.Concat(ta_aux).ToList();
            }
            foreach (var ta in turmaAlunos){
                Pessoa p = db.Pessoa.Find(ta.IdPessoa);
                if(p != null)
                    alunos.Add(p);
            }
            db.Dispose();
            return alunos;
        }

        protected List<Pessoa> GetPessoasMatriz(){
            Context db = new Context();
            List<Instituicao> instituicoes = GetMinhasInstituicoes();
            if(instituicoes == null){
                db.Dispose();
                return null;
            }
            List<Pessoa> pessoas = new List<Pessoa>();
            foreach (var i in instituicoes){
                List<Pessoa> p_aux = db.Pessoa.Where(p => p.IdInstituicao == i.IdInstituicao).ToList();
                if(p_aux != null)
                    pessoas = pessoas.Concat(p_aux).ToList();
            }
            db.Dispose();
            return pessoas;
        }

        //Dado um IdTurmaDisciplinaAutor (tda_id) devolve nome de disciplina e turma respectivamente
        protected (string, string) GetNomeTurmaNomeDisciplina(int tda_id){
            Context db = new Context();
            TurmaDisciplinaAutor tda = db.TurmaDisciplinaAutor.Find(tda_id);
            if(tda == null) return ("", "");
            DisciplinaTurma dt = db.DisciplinaTurma.Find(tda.IdDisciplinaTurma);
            if(dt == null) return ("", "");
            Turma t = db.Turma.Find(dt.IdTurma);
            if(t == null) return ("", "");
            Disciplina d = db.Disciplina.Find(dt.IdDisciplina);
            if(d == null) return ("", "");
            db.Dispose();
            return (d.Nome, t.Serie);
        }

        protected List<Atividade> GetMinhasAtividades(){
            Context db = new Context();
            int id =(int)Session["IdPessoa"];
            Pessoa p = db.Pessoa.Find(id);
            List<TurmaDisciplinaAutor> tdas = db.TurmaDisciplinaAutor.Where(tda => tda.IdAutor == p.IdPessoa).ToList();
            List<Atividade> atividades = new List<Atividade>();
            if(tdas != null)
                foreach (var tda in tdas){
                    List<Atividade> atividade_aux = db.Atividade.Where(a => a.IdTurmaDisciplinaAutor == tda.IdTurmaDisciplinaAutor && !atividades.Contains(a)).ToList();
                    atividades = atividades.Concat(atividade_aux).ToList();
                }
            db.Dispose();
            return atividades;
        }

        protected List<Instituicao> GetMinhasInstituicoes(){
            Context db = new Context();
            int idMatriz = (int)Session["IdMatriz"];
            List<Instituicao> instituicao = db.Instituicao.Where(i => i.IdMatriz == idMatriz || i.IdInstituicao == idMatriz).ToList();
            db.Dispose();
            if(instituicao == null)
                instituicao = new List<Instituicao>();
            return instituicao;
        }
        protected Instituicao FindMinhaInstituicao(int? id){
            if(id == null) return null;
            Context db = new Context();
            int idMatriz = (int)Session["IdMatriz"];
            Instituicao instituicao = db.Instituicao.Where(i => i.IdInstituicao == id && (i.IdMatriz == idMatriz || i.IdInstituicao == idMatriz)).FirstOrDefault();
            db.Dispose();
            return instituicao;
        }
    }
}