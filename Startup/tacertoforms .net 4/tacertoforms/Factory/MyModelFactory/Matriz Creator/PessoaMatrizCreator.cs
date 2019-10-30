using System.Linq;
using System.Collections.Generic;
using TaCertoForms.Models;
using TaCertoForms.Contexts;

namespace TaCertoForms.Factory{
    public class PessoaMatrizCreator : BaseCreator, IFactoryPessoa{
        public PessoaMatrizCreator(int IdMatriz, int IdPessoa) : base(IdMatriz,IdPessoa) {}

        public Pessoa FindPessoa(int? id){
            if(id == null) return null;
            Context db = new Context();
            Pessoa pessoa = db.Pessoa.Find(id);
            if(pessoa == null) return null;
            Instituicao instituicao = db.Instituicao.Find(pessoa.IdInstituicao);
            if(instituicao == null) return null;
            if(instituicao.IdInstituicao == IdMatriz || (instituicao.IdMatriz != null && instituicao.IdMatriz == IdMatriz))
                return pessoa;
            db.Dispose();
            return null;
        }
        public List<Pessoa> PessoaList(){
            Context db = new Context();
            List<int> idAuxList;
            
            List<Instituicao> instituicaoList = db.Instituicao.Where(i => i.IdInstituicao == IdMatriz || (i.IdMatriz != null && i.IdMatriz == IdMatriz)).ToList();
            if(instituicaoList == null || instituicaoList.Count == 0) return null;
            idAuxList = new List<int>();
            foreach (var i in instituicaoList) idAuxList.Add(i.IdInstituicao);

            List<Pessoa> pessoaList = db.Pessoa.Where(p => idAuxList.Contains(p.IdInstituicao)).ToList();
            if(pessoaList == null || pessoaList.Count == 0) return null;

            db.Dispose();
            return pessoaList;
        }
        public Pessoa CreatePessoa(Pessoa pessoa){
            Context db = new Context();

            Instituicao instituicao = db.Instituicao.Find(pessoa.IdInstituicao);
            if(instituicao == null) return null;
            if(instituicao.IdInstituicao != IdMatriz && (instituicao.IdMatriz == null || instituicao.IdMatriz != IdMatriz))
                return null;

            db.Pessoa.Add(pessoa);
            db.SaveChanges();
            return pessoa;
        }
        public Pessoa EditPessoa(Pessoa pessoa){
            Context db = new Context();

            Pessoa pessoa_aux = db.Pessoa.Find(pessoa.IdPessoa);
            if(pessoa_aux == null) return null;
            
            Instituicao instituicao = db.Instituicao.Find(pessoa_aux.IdInstituicao);
            if(instituicao == null) return null;
            if(instituicao.IdInstituicao != IdMatriz && (instituicao.IdMatriz == null || instituicao.IdMatriz != IdMatriz))
                return null;

            instituicao = db.Instituicao.Find(pessoa.IdInstituicao);
            if(instituicao == null) return null;
            if(instituicao.IdInstituicao != IdMatriz && (instituicao.IdMatriz == null || instituicao.IdMatriz != IdMatriz))
                return null;

            db.Dispose();
            db = new Context();
            db.Entry(pessoa).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            db.Dispose();
            return pessoa;
        }
        public bool DeletePessoa(int? id){
            if(id == null) return false;
            Context db = new Context();
            Pessoa pessoa = db.Pessoa.Find(id);
            if(pessoa == null) return false;
            
            Instituicao instituicao = db.Instituicao.Find(pessoa.IdInstituicao);
            if(instituicao == null) return false;
            if(instituicao.IdInstituicao != IdMatriz && (instituicao.IdMatriz == null || instituicao.IdMatriz != IdMatriz))
                return false;

            db.Pessoa.Remove(pessoa);
            db.SaveChanges();
            db.Dispose();
            return true;
        }
    }
}