using System;
using System.Collections.Generic;
using TaCertoForms.Models;
using Util;

namespace TaCertoForms.Models{
    public class FaseNormal : IFase{
        private int id;
        public int Id {
            get{ return id; }
            set{ id = value; }
        }
        private int usuarioId;
        public int UsuarioId {
            get{ return usuarioId; }
            set{ usuarioId = value; }
        }
        private string chave;
        public string Chave {
            get{ return chave; }
            set{ chave = value; }
        }
        private int idTipoFase;
        public int IdTipoFase {
            get{ return idTipoFase; }
            set{ idTipoFase = value; }
        }
        private string descricao;
        public string Descricao {
            get{ return descricao; }
            set{ descricao = value; }
        }
        private List<IDesafioDeFase> desafioDeFaseNormal;
        public List<IDesafioDeFase> Desafios {
            get{ return desafioDeFaseNormal; }
            set{ desafioDeFaseNormal = value; }
        }
    }
}