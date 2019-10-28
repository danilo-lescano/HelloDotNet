using System.Linq;
using System.Collections.Generic;
using TaCertoForms.Models;
using TaCertoForms.Contexts;

namespace TaCertoForms.Factory{
    //CLASSE AtividadeMatrizCreator - Responsavel por pegar no banco de dados apenas as Atividades relacionadas a uma determinada matriz
    public class AtividadeMatrizCreator : BaseCreator, IFactoryAtividade{
        public AtividadeMatrizCreator(int IdMatriz, int IdPessoa) : base(IdMatriz,IdPessoa) {}

        public Atividade FindAtividade(int? id){
            throw new System.NotImplementedException();
        }
        public List<Atividade> AtividadeList(){
            Context db = new Context();
            Pessoa pessoa = db.Pessoa.Find(IdPessoa);
            List<TurmaDisciplinaAutor> turmaDisciplinaAutorList = db.TurmaDisciplinaAutor.Where(tda => tda.IdAutor == pessoa.IdPessoa).ToList();
            List<Atividade> atividadeList = new List<Atividade>();
            if(turmaDisciplinaAutorList != null)
                foreach (var tda in turmaDisciplinaAutorList){
                    List<Atividade> atividadeList_aux = db.Atividade.Where(a => a.IdTurmaDisciplinaAutor == tda.IdTurmaDisciplinaAutor && !atividadeList.Contains(a)).ToList();
                    atividadeList = atividadeList.Concat(atividadeList_aux).ToList();
                }
            db.Dispose();
            return atividadeList;
        }

        public Atividade CreateAtividade(int? id){
            throw new System.NotImplementedException();
        }

        public Atividade EditAtividade(int? id){
            throw new System.NotImplementedException();
        }

        public bool DeleteAtividade(int? id){
            throw new System.NotImplementedException();
        }
    }
}