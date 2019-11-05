using System.Linq;
using System.Collections.Generic;
using TaCertoForms.Models;
using TaCertoForms.Contexts;

namespace TaCertoForms.Factory{
    public class TurmaDisciplinaAutorProfessorCreator : BaseCreator, IFactoryTurmaDisciplinaAutor{

        public TurmaDisciplinaAutorProfessorCreator(int IdMatriz, int IdPessoa) : base(IdMatriz, IdPessoa) { }

        public TurmaDisciplinaAutor FindTurmaDisciplinaAutor(int? id){
            if(id == null) return null;
            Context db = new Context();
            TurmaDisciplinaAutor turmaDisciplinaAutor = db.TurmaDisciplinaAutor.Where(tda => tda.IdTurmaDisciplinaAutor == id && tda.IdPessoa == IdPessoa).FirstOrDefault();
            return turmaDisciplinaAutor;
        }

        public List<TurmaDisciplinaAutor> TurmaDisciplinaAutorList(){
            Context db = new Context();
            List<TurmaDisciplinaAutor> turmaDisciplinaAutor = db.TurmaDisciplinaAutor.Where(tda => tda.IdPessoa == IdPessoa).ToList();
            return turmaDisciplinaAutor;
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