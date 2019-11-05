using System.Linq;
using System.Collections.Generic;
using TaCertoForms.Models;
using TaCertoForms.Contexts;

namespace TaCertoForms.Factory{
    //CLASSE InstituicaoProfessorCreator - Responsavel por pegar no banco de dados apenas as Instituicoes relacionadas a uma determinada matriz
    public class InstituicaoProfessorCreator : BaseCreator, IFactoryInstituicao{
        public InstituicaoProfessorCreator(int IdMatriz, int IdPessoa) : base(IdMatriz,IdPessoa) {}

        public Instituicao FindInstituicao(int? id){
            Context db = new Context();
            Pessoa pessoa = db.Pessoa.Find(IdPessoa);
            if(pessoa == null) return null;
            Instituicao instituicao = db.Instituicao.Find(pessoa.IdInstituicao);
            if(instituicao == null) return null;
            return instituicao;
        }

        public List<Instituicao> InstituicaoList(){
            Context db = new Context();
            Pessoa pessoa = db.Pessoa.Find(IdPessoa);
            if(pessoa == null) return null;
            List<Instituicao> instituicaoList = db.Instituicao.Where(i => i.IdInstituicao == pessoa.IdInstituicao).ToList();
            return instituicaoList;
        }

        public Instituicao CreateInstituicao(Instituicao instituicao){
            throw new System.NotImplementedException();
        }

        public Instituicao EditInstituicao(Instituicao instituicao){
            throw new System.NotImplementedException();
        }

        public bool DeleteInstituicao(int? id){
            throw new System.NotImplementedException();
        }
    }
}