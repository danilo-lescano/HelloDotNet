using System.Collections.Generic;
using TaCertoForms.Models;
using TaCertoForms.Contexts;

namespace TaCertoForms.Factory{
    //CLASSE AtividadeMatrizCreator - Responsavel por pegar no banco de dados apenas as Atividades relacionadas a uma determinada matriz
    public class AtividadeMatrizCreator : IAtividade{
        private Context db = new Context();

        public Atividade FindAtividade(int? id){
            return null;
        }
        public List<Atividade> AtividadeList(){
            return null;
        }
    }
}