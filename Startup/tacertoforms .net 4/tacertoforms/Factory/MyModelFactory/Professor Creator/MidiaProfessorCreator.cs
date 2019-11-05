using System;
using System.Web;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using TaCertoForms.Contexts;
using TaCertoForms.Models;

namespace TaCertoForms.Factory{
    public class MidiaProfessorCreator : BaseCreator, IFactoryMidia{
        public MidiaProfessorCreator(HttpSessionStateBase session) : base(session) { }
        public Midia CreateMidia(int? IdOrigem, string Tabela, Midia midia){
            throw new NotImplementedException();
        }

        public bool DeleteMidia(Guid? id){
            throw new NotImplementedException();
        }

        public Midia EditMidia(int? IdOrigem, string Tabela, Midia midia){
            throw new NotImplementedException();
        }

        public Midia FindMidia(int? IdOrigem, string Tabela){
            throw new NotImplementedException();
        }

        public bool HasPermissionMidia(int? IdOrigem, string Tabela){
            throw new NotImplementedException();
        }

        public List<Midia> MidiaList(int? IdOrigem, string Tabela){
            throw new NotImplementedException();
        }
    }
}