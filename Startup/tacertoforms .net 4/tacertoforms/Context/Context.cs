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

            modelBuilder.Entity<Atividade>()
                .HasRequired(A => A.TurmaDisciplinaAutor)
                .WithMany()
                .HasForeignKey(A => A.IdTurmaDisciplinaAutor)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<DisciplinaTurma>()
                .HasRequired(DT => DT.Turma)
                .WithMany()
                .HasForeignKey(DT => DT.IdTurma)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<DisciplinaTurma>()
                .HasRequired(DT => DT.Disciplina)
                .WithMany()
                .HasForeignKey(DT => DT.IdDisciplina)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Instituicao>()
                .HasRequired(I => I.EnderecoPrincipal)
                .WithMany()
                .HasForeignKey(I => I.IdEnderecoPrincipal)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Instituicao>()
                .HasRequired(I => I.EnderecoCobranca)
                .WithMany()
                .HasForeignKey(I => I.IdEnderecoCobranca)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<LogLogin>()
                .HasRequired(LL => LL.Pessoa)
                .WithMany()
                .HasForeignKey(LL => LL.IdPessoa)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Pessoa>()
                .HasRequired(P => P.Instituicao)
                .WithMany()
                .HasForeignKey(P => P.IdInstituicao)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Questao>()
                .HasRequired(Q => Q.Atividade)
                .WithMany()
                .HasForeignKey(Q => Q.IdAtividade)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Questao>()
                .HasRequired(Q => Q.TipoQuestao)
                .WithMany()
                .HasForeignKey(Q => Q.IdTipoQuestao)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Turma>()
                .HasRequired(T => T.Instituicao)
                .WithMany()
                .HasForeignKey(T => T.IdInstituicao)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<TurmaDisciplinaAutor>()
                .HasRequired(T => T.Autor)
                .WithMany()
                .HasForeignKey(T => T.IdAutor)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<TurmaDisciplinaAutor>()
                .HasRequired(T => T.DisciplinaTurma)
                .WithMany()
                .HasForeignKey(T => T.IdDisciplinaTurma)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<TurmaAluno>()
                .HasRequired(T => T.Turma)
                .WithMany()
                .HasForeignKey(T => T.IdTurma)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<TurmaAluno>()
                .HasRequired(T => T.Pessoa)
                .WithMany()
                .HasForeignKey(T => T.IdPessoa)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}