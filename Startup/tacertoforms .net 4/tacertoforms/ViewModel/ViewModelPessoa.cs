using System.Collections.Generic;

namespace TaCertoForms.Models {
    public class ViewModelPessoa{
        public int IdPessoa { get; set; }
        public int IdInstituicao { get; set; }
        public string NomeFantasia { get; set; }
        public Perfil Perfil { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public List<Turma> Turma { get; set; } = new List<Turma>();
        public int IdTurmaAluno { get; set; }
        public List<Instituicao> Instituicao { get; set; } = new List<Instituicao>();

        public Pessoa Pessoa {
            get{
                return new Pessoa(){
                    IdPessoa = this.IdPessoa,
                    Perfil   = this.Perfil,
                    Nome     = this.Nome,
                    CPF      = this.CPF,
                    Email    = this.Email
                };
            }
            set{
                this.IdPessoa = value.IdPessoa;
                this.Perfil = value.Perfil;
                this.Nome = value.Nome;
                this.CPF = value.CPF;
                this.Email = value.Email;
            }
        }
    }
}