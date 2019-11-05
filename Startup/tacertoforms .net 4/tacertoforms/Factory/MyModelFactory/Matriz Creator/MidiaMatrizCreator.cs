using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

using TaCertoForms.Contexts;
using TaCertoForms.Models;

namespace TaCertoForms.Factory{
    public class MidiaMatrizCreator : BaseCreator, IFactoryMidia{
        public MidiaMatrizCreator(HttpSessionStateBase session) : base(session) { }

        public Midia CreateMidia(int? IdOrigem, string Tabela, Midia midia){
            if (IdOrigem == null || Tabela == null || Tabela == "" || midia == null) return null;

            if (HasPermissionMidia(IdOrigem, Tabela)){
                Context db = new Context();
                db.Midia.Add(midia);
                db.SaveChanges();
                db.Dispose();
                return midia;
            }
            return null;
        }

        public bool DeleteMidia(Guid? id){
            if (id == null) return false;

            Context db = new Context();
            Midia midia = db.Midia.Find(id);
            if (midia == null) return false;

            if (HasPermissionMidia(midia.IdOrigem, midia.Tabela)){
                //Deletando arquivo
                var path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Content/images/upload/" + midia.Tabela + '/'), midia.IdMidia + midia.Extensao);
                if (File.Exists(path))
                    File.Delete(path);

                db.Midia.Remove(midia);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public Midia EditMidia(int? IdOrigem, string Tabela, Midia midia){
            throw new NotImplementedException();
        }

        public Midia FindMidia(int? IdOrigem, string Tabela){
            if (IdOrigem == null || Tabela == null || Tabela == "") return null;
            
            if(HasPermissionMidia(IdOrigem, Tabela)) {
                Context db = new Context();
                Midia midia = db.Midia.Where(x => x.IdOrigem == IdOrigem && x.Tabela == Tabela).FirstOrDefault<Midia>();
                if (midia == null) return null;

                db.Dispose();
                return midia;
            }
            return null;
        }

        public bool HasPermissionMidia(int? IdOrigem, string Tabela){
            if (IdOrigem == null || Tabela == null || Tabela == "") return false;

            Context db = new Context();
            Pessoa pessoa = db.Pessoa.Find(IdPessoa);
            if (pessoa == null) return false;

            //Buscando todas as instituições matriz e filiais relacionadas ao usuário cadastrado
            List<Instituicao> instituicaoList = db.Instituicao.Where(i => i.IdInstituicao == IdMatriz || (i.IdMatriz != null && i.IdMatriz == IdMatriz)).ToList();
            if (instituicaoList == null || instituicaoList.Count == 0) return false;
            List<int> idInstituicaoList = new List<int>();
            foreach (var i in instituicaoList) idInstituicaoList.Add(i.IdInstituicao);

            if(Tabela == "Instituicao"){
                if(pessoa.Perfil.Equals(Perfil.Administrador)){
                    if(idInstituicaoList.Contains((int)IdOrigem)) //Só irá retornar se quem estiver pedindo a midia pertencer a qualquer instituição relacionada a matriz
                        return true;
                }
            }
            else if(Tabela == "Pessoa"){
                if(pessoa.Perfil.Equals(Perfil.Administrador)){
                    Pessoa pessoaFind = db.Pessoa.Find(IdOrigem);
                    if(pessoaFind == null) return false;
                    if(idInstituicaoList.Contains((int)pessoaFind.IdInstituicao))
                        return true;
                }
            } else {
                return false; //A tabela que o usuário está tentando capturar mídia, não foi tratada nenhuma regra de permissão.
            }
            return false;            
        }

        public List<Midia> MidiaList(int? IdOrigem, string Tabela){
            throw new NotImplementedException();
        }
    }
}