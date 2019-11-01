using System.Linq;
using System.Collections.Generic;
using TaCertoForms.Models;
using TaCertoForms.Contexts;

namespace TaCertoForms.Factory{
    //CLASSE AtividadeProfessorCreator - Responsavel por pegar no banco de dados apenas as Atividades relacionadas a uma determinada matriz
    public class AtividadeProfessorCreator : BaseCreator, IFactoryAtividade{
        public AtividadeProfessorCreator(int IdMatriz, int IdPessoa) : base(IdMatriz,IdPessoa) {}

        public List<Atividade> AtividadeList()
        {
            throw new System.NotImplementedException();
        }

        public Atividade CreateAtividade(Atividade atividade)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteAtividade(int? id)
        {
            throw new System.NotImplementedException();
        }

        public Atividade EditAtividade(Atividade atividade)
        {
            throw new System.NotImplementedException();
        }

        public Atividade FindAtividade(int? id)
        {
            throw new System.NotImplementedException();
        }
    }
}