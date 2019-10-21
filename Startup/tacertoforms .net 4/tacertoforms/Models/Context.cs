using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace tacertoforms.Models {
    public class Context : DbContext {
        public DbSet<Midia> Midias { get; set; }
        public DbSet<Atividade> Atividades { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<DisciplinaTurma> DisciplinaTurmas { get; set; }
        public DbSet<TurmaDisciplinaProfessor> TurmaDisciplinaProfessors { get; set; }
        public DbSet<TurmaAluno> TurmaAlunoes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Instituicao> Instituicaos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Questao> Questaos { get; set; }
        public DbSet<TipoQuestao> TipoQuestaos { get; set; }
        public DbSet<Turma> Turmas { get; set; }        
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            Database.SetInitializer<Context>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}