using System.Linq;
using System.Collections.Generic;
using TaCertoForms.Models;
using TaCertoForms.Contexts;

namespace TaCertoForms.Factory{
    //CLASSE EnderecoMatrizCreator - Responsavel por pegar no banco de dados apenas as endereços relacionadas a uma determinada matriz
    public class EnderecoMatrizCreator : BaseCreator, IFactoryEndereco{
        public EnderecoMatrizCreator(int IdMatriz, int IdPessoa) : base(IdMatriz,IdPessoa) {}

        public Endereco FindEndereco(int? id){
            if(id == null) return null;
            Context db = new Context();
            Endereco endereco = db.Endereco.Find(id);
            if(endereco == null) return null;
            List<Instituicao> instituicoes = db.Instituicao.Where(i => i.IdEnderecoCobranca == endereco.IdEndereco || i.IdEnderecoPrincipal == endereco.IdEndereco).ToList();
            foreach (Instituicao i in instituicoes){
                if(i.IdInstituicao == IdMatriz || (i.IdMatriz != null && i.IdMatriz == IdMatriz))
                    return endereco;
            }
            db.Dispose();
            return null;
        }
        public List<Endereco> EnderecoList(){
            Context db = new Context();
            List<Instituicao> instituicaoList = db.Instituicao.Where(i => i.IdInstituicao == IdMatriz || (i.IdMatriz != null && i.IdMatriz == IdMatriz)).ToList();
            List<int> idEndereco = new List<int>();
            foreach (Instituicao i in instituicaoList){
                if(!idEndereco.Contains(i.IdEnderecoCobranca))
                    idEndereco.Add(i.IdEnderecoCobranca);
                if(!idEndereco.Contains(i.IdEnderecoPrincipal))
                    idEndereco.Add(i.IdEnderecoPrincipal);
            }
            List<Endereco> enderecoList = db.Endereco.Where(e => idEndereco.Contains(e.IdEndereco)).ToList();
            if(enderecoList == null || enderecoList.Count == 0) return null;
            db.Dispose();
            return enderecoList;
        }

        public Endereco CreateEndereco(Endereco endereco){
            Context db = new Context();
            Endereco endereco_aux = db.Endereco.Find(endereco.IdEndereco);
            if(endereco_aux != null)
                return null;
            db.Dispose();
            db = new Context();
            db.Endereco.Add(endereco);
            db.SaveChanges();
            db.Dispose();
            return endereco;
        }

        public Endereco EditEndereco(Endereco endereco){
            Context db = new Context();
            Endereco endereco_aux = db.Endereco.Find(endereco.IdEndereco);
            if(endereco_aux == null)
                return null;
            db.Dispose();
            db = new Context();
            List<Instituicao> instituicaoList = db.Instituicao.Where(i => (i.IdInstituicao == IdMatriz || i.IdMatriz == IdMatriz) && (i.IdEnderecoCobranca == endereco.IdEndereco || i.IdEnderecoPrincipal == endereco.IdEndereco)).ToList();
            if(instituicaoList == null || instituicaoList.Count == 0)
                return null;
            db.Entry(endereco).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            db.Dispose();
            return endereco;
        }

        public bool DeleteEndereco(int? id){
            if(id == null) return false;
            Context db = new Context();
            Endereco endereco = db.Endereco.Find(id);
            if(endereco == null) return false;
            db.Dispose();
            db = new Context();
            List<Instituicao> instituicaoList = db.Instituicao.Where(i => (i.IdInstituicao == IdMatriz || i.IdMatriz == IdMatriz) && (i.IdEnderecoCobranca == endereco.IdEndereco || i.IdEnderecoPrincipal == endereco.IdEndereco)).ToList();
            if(instituicaoList == null || instituicaoList.Count == 0)
                return false;
            db.Endereco.Remove(endereco);
            db.SaveChanges();
            db.Dispose();
            return true;
        }
    }
}