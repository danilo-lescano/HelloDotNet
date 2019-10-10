using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace tacertoforms.Models {
    public class ViewModelAtividade {
        public int IdAtividade { get; set; }
        public int IdTurmaDisciplinaProfessor { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int NumeroTentativas { get; set; }
        public bool IsAleatorio { get; set; }
        public bool IsProva { get; set; }

        public List<Questao> Questoes { get; set; } = new List<Questao>();


        public Atividade Atividade {
            get{
                return new Atividade {
                    IdAtividade = this.IdAtividade,
                    IdTurmaDisciplinaProfessor = this.IdTurmaDisciplinaProfessor,
                    DataInicio = this.DataInicio,
                    DataFim = this.DataFim,
                    NumeroTentativas = this.NumeroTentativas,
                    IsAleatorio = this.IsAleatorio,
                    IsProva = this.IsProva
                };
            }
            set{
                this.IdAtividade = value.IdAtividade;
                this.IdTurmaDisciplinaProfessor = value.IdTurmaDisciplinaProfessor;
                this.DataInicio = value.DataInicio;
                this.DataFim = value.DataFim;
                this.NumeroTentativas = value.NumeroTentativas;
                this.IsAleatorio = value.IsAleatorio;
                this.IsProva = value.IsProva;
            }
        }
    }
}