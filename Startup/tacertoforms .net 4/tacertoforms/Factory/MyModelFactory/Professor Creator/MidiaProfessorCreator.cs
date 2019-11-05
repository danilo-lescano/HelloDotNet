using System;
using System.Web;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using TaCertoForms.Contexts;
using TaCertoForms.Models;

namespace TaCertoForms.Factory
{
    public class MidiaProfessorCreator : BaseCreator, IFactoryMidia
    {
        public MidiaProfessorCreator(HttpSessionStateBase session) : base(session) {}
        public Midia CreateMidia(int? IdOrigem, string Tabela, Midia midia)
        {
            if (IdOrigem == null || Tabela == null || Tabela == "" || midia == null) return null;

            if (HasPermissionMidia(IdOrigem, Tabela))
            {
                Context db = new Context();
                db.Midia.Add(midia);
                db.SaveChanges();
                db.Dispose();
                return midia;
            }
            return null;
        }

        public bool DeleteMidia(Guid? id)
        {
            if (id == null) return false;

            Context db = new Context();
            Midia midia = db.Midia.Find(id);
            if (midia == null) return false;

            if (HasPermissionMidia(midia.IdOrigem, midia.Tabela))
            {
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

        public Midia FindMidia(int? IdOrigem, string Tabela)
        {
            if (IdOrigem == null || Tabela == null || Tabela == "") return null;

            if (HasPermissionMidia(IdOrigem, Tabela))
            {
                Context db = new Context();
                Midia midia = db.Midia.Where(x => x.IdOrigem == IdOrigem && x.Tabela == Tabela).FirstOrDefault<Midia>();
                if (midia == null) return null;

                db.Dispose();
                return midia;
            }
            return null;
        }

        public bool HasPermissionMidia(int? IdOrigem, string Tabela)
        {
            if (IdOrigem == null || Tabela == null || Tabela == "") return false;

            Context db = new Context();
            Pessoa pessoa = db.Pessoa.Find(IdPessoa);
            if (pessoa == null) return false;

            //Buscando todas as instituições matriz e filiais relacionadas ao usuário cadastrado
            if (Tabela == "Questao") {
                List<int> idAuxList = new List<int>();
                
                List<TurmaDisciplinaAutor> turmaDisciplinaAutorList = db.TurmaDisciplinaAutor.Where(tda => tda.IdAutor == pessoa.IdPessoa).ToList();
                if (turmaDisciplinaAutorList == null || turmaDisciplinaAutorList.Count == 0) return false;
                idAuxList = new List<int>();
                foreach (var tda in turmaDisciplinaAutorList) idAuxList.Add(tda.IdTurmaDisciplinaAutor); //Populando idAuxList com IdTurmaDisciplinaAutor da instituição

                List<Atividade> atividadeList = db.Atividade.Where(a => idAuxList.Contains(a.IdTurmaDisciplinaAutor)).ToList();
                if (atividadeList == null || atividadeList.Count == 0) return false;
                idAuxList = new List<int>();
                foreach (var at in atividadeList) idAuxList.Add(at.IdAtividade); //Populando idAuxList com IdTurmaDisciplinaAutor da instituição
                if (atividadeList == null || atividadeList.Count == 0) return false;

                List<Questao> questaoList = db.Questao.Where(q => idAuxList.Contains(q.IdAtividade)).ToList();
                if (questaoList == null || questaoList.Count == 0) return false;

                db.Dispose();
                return true;
            } 
            return false; //A tabela que o usuário está tentando capturar mídia, não foi tratada nenhuma regra de permissão.
                       
        }

        public List<Midia> MidiaList(int? IdOrigem, string Tabela){
            throw new NotImplementedException();
        }
    }
}