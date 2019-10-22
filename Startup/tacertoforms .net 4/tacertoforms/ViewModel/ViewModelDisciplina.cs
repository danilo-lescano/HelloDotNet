using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaCertoForms.Models {
    public class ViewModelDisciplina {
        public int IdDisciplina { get; set; }
        public int IdDisciplinaTurma { get; set; }
        public int IdTurmaDisciplinaProfessor { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string idTurmas { get; set; }
        public List<Turma> Turmas { get; set; } = new List<Turma>();

        public int[] GetTurmaIds(){
            string[] turmas = idTurmas.Split(';');
            int[] idArr = new int[turmas.Length];
            for(int i = 0; i < turmas.Length; i++)
                idArr[i] = int.Parse(turmas[i]);
            return idArr;
        }

        public Disciplina Disciplina {
            get{
                return new Disciplina(){
                    IdDisciplina = this.IdDisciplina,
                    Nome = this.Nome,
                    Descricao = this.Descricao
                };
            }
            set{
                this.IdDisciplina = value.IdDisciplina;
                this.Nome = value.Nome;
                this.Descricao = value.Descricao;
            }
        }

        public void EncherTurmas(){
            foreach (var t in Turmas){
                if(idTurmas == null || idTurmas == "")
                    idTurmas = "" + t.IdTurma;
                else
                    idTurmas += ";" + t.IdTurma;
            }
        }

        public bool hasIdTurma(int id){
            foreach (var t in Turmas)
                if(t.IdTurma == id)
                    return true;
            return false;
        }
    }
}