using System.Linq;
using System.Collections.Generic;
using TaCertoForms.Models;
using TaCertoForms.Contexts;

namespace TaCertoForms.Factory{
    public class TurmaDisciplinaAutorProfessorCreator : BaseCreator, IFactoryTurmaDisciplinaAutor{

        public TurmaDisciplinaAutorProfessorCreator(int IdMatriz, int IdPessoa) : base(IdMatriz, IdPessoa) { }

        public TurmaDisciplinaAutor FindTurmaDisciplinaAutor(int? id){
            throw new System.NotImplementedException();
        }

        public List<TurmaDisciplinaAutor> TurmaDisciplinaAutorList(){
            throw new System.NotImplementedException();
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