using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tacertoforms.Models
{
    public class ViewModelQuestao
    {
        public int IdQuestao { get; set; }
        public int IdAtividade { get; set; }
        public int IdTipoQuestao { get; set; }
        public string Titulo { get; set; }
        public string Enunciado { get; set; }
        public string JsonQuestao { get; set; }
        public int PesoNota { get; set; }
        public TipoQuestao TipoQuestao { get; set; }
        public Questao Questao
        {
            get
            {
                return new Questao()
                {
                    IdQuestao = this.IdQuestao,
                    IdAtividade = this.IdAtividade,
                    IdTipoQuestao = this.IdTipoQuestao,
                    Titulo = this.Titulo,
                    Enunciado = this.Enunciado,
                    JsonQuestao = this.JsonQuestao,
                    PesoNota = this.PesoNota
                };
            }
            set
            {
                    this.IdQuestao = value.IdQuestao;
                    this.IdAtividade = value.IdAtividade;
                    this.IdTipoQuestao = value.IdTipoQuestao;
                    this.Titulo = value.Titulo;
                    this.Enunciado = value.Enunciado;
                    this.JsonQuestao = value.JsonQuestao;
                    this.PesoNota = value.PesoNota;
            }
        }
    }
}