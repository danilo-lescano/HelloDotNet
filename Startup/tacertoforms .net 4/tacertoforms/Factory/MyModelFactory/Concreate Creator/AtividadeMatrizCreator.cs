using System.Collections.Generic;
using TaCertoForms.Models;
using TaCertoForms.Contexts;

namespace TaCertoForms.Factory{
    //CLASSE AtividadeMatrizCreator - Responsavel por pegar no banco de dados apenas as Atividades relacionadas a uma determinada matriz
    public class AtividadeMatrizCreator : BaseCreator, IAtividade{
        private Context db = new Context();

        public AtividadeMatrizCreator(int IdMatriz, int IdPessoa) : base(IdMatriz,IdPessoa) {}

        public Atividade FindAtividade(int? id){
            return null;
        }
        public List<Atividade> AtividadeList(){
            return null;
        }
    }
}