using System;
using System.Globalization; 
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaCertoForms.Models {
    public class ViewModelAtividade {
        public int IdAtividade { get; set; }
        public int IdTurmaDisciplinaAutor { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Titulo { get; set; }
        public int NumeroTentativas { get; set; }
        public bool IsAleatorio { get; set; }
        public bool IsProva { get; set; }
        public List<Questao> Questoes { get; set; } = new List<Questao>();     

        public string nome_da_turma { get; set; }
        public string nome_da_materia { get; set; }
        public int IdTurma { get; set; }
        public int IdDisciplinaTurma { get; set; }
        public string Periodo { get; set; }
        private void assertPeriodo(){
            string inicio, fim;
            string[] datas = Periodo.Split('-');
            if(datas.Length != 2) return;
            inicio = datas[0].Trim();
            fim = datas[1].Trim();
            DataInicio = DateTime.Parse(inicio);
            DataFim = DateTime.Parse(fim);
        }
        public void setPeriodo(){
            Periodo = DataInicio.ToString("dd/MM/yyyy h:mm:ss", DateTimeFormatInfo.InvariantInfo) + " - " + DataFim.ToString("dd/MM/yyy", DateTimeFormatInfo.InvariantInfo);
        }        

        public Atividade Atividade {
            get{
                assertPeriodo();
                return new Atividade {
                    IdAtividade = this.IdAtividade,
                    IdTurmaDisciplinaAutor = this.IdTurmaDisciplinaAutor,
                    DataInicio = this.DataInicio,
                    DataFim = this.DataFim,
                    Titulo = this.Titulo,
                    NumeroTentativas = this.NumeroTentativas,
                    IsAleatorio = this.IsAleatorio,
                    IsProva = this.IsProva
                };
            }
            set{
                this.IdAtividade = value.IdAtividade;
                this.IdTurmaDisciplinaAutor = value.IdTurmaDisciplinaAutor;
                this.DataInicio = value.DataInicio;
                this.DataFim = value.DataFim;
                this.Titulo = value.Titulo;
                this.NumeroTentativas = value.NumeroTentativas;
                this.IsAleatorio = value.IsAleatorio;
                this.IsProva = value.IsProva;
            }
        }
    }
}