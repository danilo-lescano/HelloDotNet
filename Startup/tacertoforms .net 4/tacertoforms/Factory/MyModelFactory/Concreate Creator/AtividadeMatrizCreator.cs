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
            throw new System.NotImplementedException();
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