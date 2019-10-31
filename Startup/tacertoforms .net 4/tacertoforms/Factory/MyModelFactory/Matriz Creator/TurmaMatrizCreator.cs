using System.Linq;
using System.Collections.Generic;
using TaCertoForms.Models;
using TaCertoForms.Contexts;

namespace TaCertoForms.Factory{
    public class TurmaMatrizCreator : BaseCreator, IFactoryTurma{
        
        public TurmaMatrizCreator(int IdMatriz, int IdPessoa) : base(IdMatriz, IdPessoa) { }
        
        public Turma CreateTurma(Turma turma){
            Context db = new Context();
            Pessoa pessoa = db.Pessoa.Find(IdPessoa);
            Instituicao instituicao = db.Instituicao.Find(turma.IdInstituicao);
            if (pessoa == null || instituicao == null) return null; //Caso seja uma requisição absurda
            
            if (instituicao.IdInstituicao == IdMatriz || (instituicao.IdMatriz != null && instituicao.IdMatriz == IdMatriz)){   
                //Salvando a turma                
                db.Turma.Add(turma);
                db.SaveChanges();
                db.Dispose();
                return turma;
            }
            return null; 
        }
        public bool DeleteTurma(int? id){            
            throw new System.NotImplementedException();
        }

        public Turma EditTurma(Turma turma){
            //TODO Como será se após vinculado turma com aluno e disciplina, o usuário mudasse a turma?
            Context db = new Context();
            Pessoa pessoa = db.Pessoa.Find(IdPessoa);
            Instituicao instituicao = db.Instituicao.Find(turma.IdInstituicao);
            if (pessoa == null || instituicao == null) return null;

            if (instituicao.IdInstituicao == IdMatriz || (instituicao.IdMatriz != null && instituicao.IdMatriz == IdMatriz)){   
                db.Entry(turma).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();                
                db.Dispose();
                return turma;
            }
            return null; //Caso deu erro ao salvar 
        }

        public Turma FindTurma(int? id){
            if (id == null) return null;

            Context db = new Context();
            Turma turma = db.Turma.Find(id);
            Instituicao instituicao = db.Instituicao.Find(turma.IdInstituicao);
            if (turma == null || instituicao == null) return null;                                                
            
            if (instituicao.IdInstituicao == IdMatriz || (instituicao.IdMatriz != null && instituicao.IdMatriz == IdMatriz))
                return turma;
            db.Dispose();
            return null;
        }

        public List<Turma> TurmaList(){
            Context db = new Context();
            Pessoa pessoa = db.Pessoa.Find(IdPessoa);            
            
            List<Instituicao> instituicaoList = db.Instituicao.Where(i => i.IdInstituicao == IdMatriz || (i.IdMatriz != null && i.IdMatriz == IdMatriz)).ToList();
            if (pessoa == null || instituicaoList == null || instituicaoList.Count == 0) return null;
            List<int> idAuxList;
            idAuxList = new List<int>();
            foreach (var i in instituicaoList) idAuxList.Add(i.IdInstituicao);
            
            if (idAuxList.Contains(IdMatriz)){                
                List<Turma> turmas = db.Turma.Where(a => idAuxList.Contains(a.IdInstituicao)).ToList();
                return turmas;
            }            
            db.Dispose();
            return null;
        }
    }
}