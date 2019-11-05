using System.Web;
using System.Linq;
using System.Collections.Generic;
using TaCertoForms.Models;
using TaCertoForms.Contexts;

namespace TaCertoForms.Factory{
    public class TurmaDisciplinaAutorProfessorCreator : BaseCreator, IFactoryTurmaDisciplinaAutor{

        public TurmaDisciplinaAutorProfessorCreator(HttpSessionStateBase session) : base(session) { }

        public TurmaDisciplinaAutor FindTurmaDisciplinaAutor(int? id){
            Context db = new Context();

            Pessoa pessoa = db.Pessoa.Find(IdPessoa);
            TurmaDisciplinaAutor tda = db.TurmaDisciplinaAutor.Find(id);
            if (pessoa == null || tda == null) return null;

            db.Dispose();
            if (tda.IdAutor == pessoa.IdPessoa) return tda;
            return null;
        }

        public List<TurmaDisciplinaAutor> TurmaDisciplinaAutorList(){
            Context db = new Context();

            Pessoa pessoa = db.Pessoa.Find(IdPessoa);
            if (pessoa == null) return null;
                        
            List<TurmaDisciplinaAutor> turmaDisciplinaAutorList = db.TurmaDisciplinaAutor.Where(tda => tda.IdAutor == pessoa.IdPessoa).ToList();
            if (turmaDisciplinaAutorList == null || turmaDisciplinaAutorList.Count == 0) return null;

            db.Dispose();
            return turmaDisciplinaAutorList;
        }

        public TurmaDisciplinaAutor CreateTurmaDisciplinaAutor(TurmaDisciplinaAutor turmaDisciplinaAutor){
            throw new System.NotImplementedException();
        }

        public TurmaDisciplinaAutor EditTurmaDisciplinaAutor(TurmaDisciplinaAutor turmaDisciplinaAutor){
            throw new System.NotImplementedException();
        }

        public bool DeleteTurmaDisciplinaAutor(int? id){
            throw new System.NotImplementedException();
        }
    }
}