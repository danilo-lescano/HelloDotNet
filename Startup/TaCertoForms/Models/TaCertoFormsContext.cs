using System;
using Microsoft.EntityFrameworkCore;

namespace TaCertoForms.Models{
    public class TaCertoFormsContext : DbContext { 
        public DbSet<Acesso> Acessos { get; set; }
        public DbSet<AcessoPessoa> AcessoPessoas { get; set; }
        //public DbSet<Atividade> Atividades { get; set; }
        //public DbSet<AtividadeResposta> AtividadeRespostas { get; set; }
        public DbSet<Instituicao> Instituicaos { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<MateriaProfessor> MateriaProfessors { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        //public DbSet<Questao> Questaos { get; set; }
        //public DbSet<QuestaoResposta> QuestaoRespostas { get; set; }
        //public DbSet<TipoQuestao> TipoQuestaos { get; set; }
        public DbSet<Turma> Turmas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder){
            optionBuilder.UseSqlServer(@"Server=localhost;Database=EFCore.Demo;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            //---------------------------------ACESSO--------------------------------//
            modelBuilder.Entity<Acesso>().ToTable("Acesso");
            //---------------------------------ACESSO--------------------------------//


            //-----------------------------ACESSO PESSOA-----------------------------//
            modelBuilder.Entity<AcessoPessoa>().ToTable("AcessoPessoa");
            modelBuilder.Entity<AcessoPessoa>()
                .HasOne(ap => ap.Acesso)
                .WithMany(ap => ap.AcessoPessoas)
                .HasForeignKey(ap => ap.IdAcesso);
            modelBuilder.Entity<AcessoPessoa>()
                .HasOne(ap => ap.Pessoa)
                .WithMany(ap => ap.AcessoPessoas)
                .HasForeignKey(ap => ap.IdPessoa);
            //-----------------------------ACESSO PESSOA-----------------------------//


            //---------------------------------PESSOA--------------------------------//
            modelBuilder.Entity<Pessoa>().ToTable("Pessoa");
            modelBuilder.Entity<Pessoa>()
                .HasOne(p => p.Instituicao)
                .WithMany(p => p.Pessoas)
                .HasForeignKey(p => p.IdInstituicao);
            //---------------------------------PESSOA--------------------------------//


            //------------------------------INSTITUIÇÃO------------------------------//
            modelBuilder.Entity<Instituicao>().ToTable("Instituicao");
            //------------------------------INSTITUIÇÃO------------------------------//


            //--------------------------------MATERIA--------------------------------//
            modelBuilder.Entity<Materia>().ToTable("Materia");
            //--------------------------------MATERIA--------------------------------//


            //---------------------------MATERIA PROFESSOR---------------------------//
            modelBuilder.Entity<MateriaProfessor>().ToTable("MateriaProfessor");
            modelBuilder.Entity<MateriaProfessor>()
                .HasOne(mp => mp.Materia)
                .WithMany(mp => mp.MateriaProfessor)
                .HasForeignKey(mp => mp.IdMateria);
            modelBuilder.Entity<MateriaProfessor>()
                .HasOne(mp => mp.Pessoa)
                .WithMany(mp => mp.MateriaProfessor)
                .HasForeignKey(mp => mp.IdPessoa);
            //---------------------------MATERIA PROFESSOR---------------------------//


            //---------------------------------TURMA---------------------------------//
            modelBuilder.Entity<Turma>().ToTable("Turma");
            //---------------------------------TURMA---------------------------------//


            //---------------------------------TURMA---------------------------------//
            modelBuilder.Entity<TurmaMateriaProfessor>().ToTable("TurmaMateriaProfessor");
            modelBuilder.Entity<TurmaMateriaProfessor>()
                .HasOne(tmp => tmp.Turma)
                .WithMany(tmp => tmp.TurmaMateriaProfessors)
                .HasForeignKey(tmp => tmp.IdTurma);
            modelBuilder.Entity<TurmaMateriaProfessor>()
                .HasOne(tmp => tmp.MateriaProfessor)
                .WithMany(tmp => tmp.TurmaMateriaProfessors)
                .HasForeignKey(tmp => tmp.IdMateriaProfessor);
            //---------------------------------TURMA---------------------------------//


        }
        /*
            modelBuilder.Entity<Livro>().Property(p => p.Titulo).HasColumnType("varchar(50)");
        */
    }
}