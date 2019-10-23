using System.Data.Entity;
using TaCertoForms.Models;

namespace TaCertoForms.Contexts {
    public class Context : DbContext {
        public DbSet<Midia> Midia { get; set; }
        public DbSet<Atividade> Atividade { get; set; }
        public DbSet<Disciplina> Disciplina { get; set; }
        public DbSet<DisciplinaTurma> DisciplinaTurma { get; set; }
        public DbSet<TurmaDisciplinaAutor> TurmaDisciplinaAutor { get; set; }
        public DbSet<TurmaAluno> TurmaAluno { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Instituicao> Instituicao { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Questao> Questao { get; set; }
        public DbSet<TipoQuestao> TipoQuestao { get; set; }
        public DbSet<Turma> Turma { get; set; }        
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            Database.SetInitializer<Context>(null);
            modelBuilder.HasDefaultSchema("TaCerto");
            base.OnModelCreating(modelBuilder);
        }
    }
}