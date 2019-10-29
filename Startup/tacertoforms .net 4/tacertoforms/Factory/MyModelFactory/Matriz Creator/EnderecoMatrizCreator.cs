using System.Linq;
using System.Collections.Generic;
using TaCertoForms.Models;
using TaCertoForms.Contexts;

namespace TaCertoForms.Factory{
    //CLASSE EnderecoMatrizCreator - Responsavel por pegar no banco de dados apenas as endereços relacionadas a uma determinada matriz
    public class EnderecoMatrizCreator {/*: BaseCreator, IFactoryEndereco{/* 
        public EnderecoMatrizCreator(int IdMatriz, int IdPessoa) : base(IdMatriz,IdPessoa) {}

        public Endereco FindEndereco(int? id){
            if(id == null) return null;
            Context db = new Context();
            Endereco endereco = db.Endereco.Find(id);
            if(endereco == null) return null;
            List<Instituicao> instituicoes = db.Instituicao.Where(i => i.IdEnderecoCobranca == endereco.IdEndereco || i.IdEnderecoPrincipal == endereco.IdEndereco).ToList();
            foreach (Instituicao i in instituicoes){
                if(i.IdInstituicao != IdMatriz && (i.IdMatriz == null || i.IdMatriz != IdMatriz))
                    return Instituicao;
            }
            db.Dispose();
            return null;
        }
        public List<Endereco> EnderecoList(){
            Context db = new Context();

            List<Endereco> EnderecoList = db.Endereco.Where(i => i.IdEndereco == IdMatriz || (i.IdMatriz != null && i.IdMatriz == IdMatriz)).ToList();
            if(EnderecoList == null || EnderecoList.Count == 0) return null;

            db.Dispose();
            return EnderecoList;
        }

        public Endereco CreateEndereco(Endereco Endereco){
            Context db = new Context();
            Endereco Endereco_aux = db.Endereco.Find(Endereco.IdEndereco);
            if(Endereco_aux != null)
                return null;
            Endereco.IdMatriz = IdMatriz;
            Endereco.IsMatriz = false;
            db.Endereco.Add(Endereco);
            db.SaveChanges();
            db.Dispose();
            return Endereco;
        }

        public Endereco EditEndereco(Endereco Endereco){
            Context db = new Context();
            Endereco Endereco_aux = db.Endereco.Find(Endereco.IdEndereco);
            if(Endereco_aux == null)
                return null;
            if(Endereco.IdMatriz != IdMatriz && Endereco.IsMatriz)
                return null;
            else if(Endereco.IdMatriz != IdMatriz && Endereco.IdEndereco != IdMatriz)
                return null;
            db.Entry(Endereco).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            db.Dispose();
            return Endereco;
        }

        public bool DeleteEndereco(int? id){
            if(id == null) return false;
            Context db = new Context();
            Endereco Endereco = db.Endereco.Find(id);
            if(Endereco == null) return false;
            if(Endereco.IdEndereco == IdMatriz || Endereco.IdMatriz != IdMatriz) return false;
            db.Endereco.Remove(Endereco);
            db.SaveChanges();
            db.Dispose();
            return true;
        }*/
    }
}