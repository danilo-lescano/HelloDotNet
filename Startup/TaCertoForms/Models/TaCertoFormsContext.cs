using System;
using Microsoft.EntityFrameworkCore;

namespace TaCertoForms.Models{
    public class TaCertoFormsContext : DbContext { 
        public DbSet<Atividade> Atividades { get; set; }
        public DbSet<AtividadeRespostaAluno> AtividadeRespostaAlunos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<DisciplinaProfessor> DisciplinaProfessors { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Instituicao> Instituicaos { get; set; }
        public DbSet<Licenca> Licencas { get; set; }
        public DbSet<LogLogin> LogLogins { get; set; }
        public DbSet<Midia> Midias { get; set; }
        public DbSet<Perfil> Perfils { get; set; }
        public DbSet<PerfilPessoa> PerfilPessoas { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<PessoaLicenca> PessoaLicencas { get; set; }
        public DbSet<Questao> Questaos { get; set; }
        public DbSet<QuestaoRespostaAluno> QuestaoRespostaAlunos { get; set; }
        public DbSet<TipoQuestao> TipoQuestaos { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<TurmaAluno> TurmaAlunos { get; set; }
        public DbSet<TurmaDisciplinaProfessor> TurmaDisciplinaProfessors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder){
            optionBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            //-------------------------------ATIVIDADE-------------------------------//
            modelBuilder.Entity<Atividade>().ToTable("Atividade", schemaName: "TaCertoForms");
            //-------------------------------ATIVIDADE-------------------------------//
            //------------------------ATIVIDADE RESPOSTA ALUNO-----------------------//
            modelBuilder.Entity<AtividadeRespostaAluno>().ToTable("AtividadeRespostaAluno", schemaName: "TaCertoForms");
            //------------------------ATIVIDADE RESPOSTA ALUNO-----------------------//
            //-------------------------------DISCIPLINA------------------------------//
            modelBuilder.Entity<Disciplina>().ToTable("Disciplina", schemaName: "TaCertoForms");
            //-------------------------------DISCIPLINA------------------------------//
            //--------------------------DISCIPLINA PROFESSOR-------------------------//
            modelBuilder.Entity<DisciplinaProfessor>().ToTable("DisciplinaProfessor", schemaName: "TaCertoForms");
            //--------------------------DISCIPLINA PROFESSOR-------------------------//
            //--------------------------------ENDERECO-------------------------------//
            modelBuilder.Entity<Endereco>().ToTable("Endereco", schemaName: "TaCertoForms");
            //--------------------------------ENDERECO-------------------------------//
            //------------------------------INSTITUICAO------------------------------//
            modelBuilder.Entity<Instituicao>().ToTable("Instituicao", schemaName: "TaCertoForms");
            //------------------------------INSTITUICAO------------------------------//
            //--------------------------------LICENCA--------------------------------//
            modelBuilder.Entity<Licenca>().ToTable("Licenca", schemaName: "TaCertoForms");
            //--------------------------------LICENCA--------------------------------//
            //-------------------------------LOG LOGIN-------------------------------//
            modelBuilder.Entity<LogLogin>().ToTable("LogLogin", schemaName: "TaCertoForms");
            //-------------------------------LOG LOGIN-------------------------------//
            //---------------------------------MIDIA---------------------------------//
            modelBuilder.Entity<Midia>().ToTable("Midia", schemaName: "TaCertoForms");
            //---------------------------------MIDIA---------------------------------//
            //---------------------------------PERFIL--------------------------------//
            modelBuilder.Entity<Perfil>().ToTable("Perfil", schemaName: "TaCertoForms");
            //---------------------------------PERFIL--------------------------------//
            //------------------------------PERFIL PESSOA----------------------------//
            modelBuilder.Entity<PerfilPessoa>().ToTable("PerfilPessoa", schemaName: "TaCertoForms");
            //------------------------------PERFIL PESSOA----------------------------//
            //---------------------------------PESSOA--------------------------------//
            modelBuilder.Entity<Pessoa>().ToTable("Pessoa", schemaName: "TaCertoForms");
            //---------------------------------PESSOA--------------------------------//
            //-----------------------------PESSOA LICENCA----------------------------//
            modelBuilder.Entity<PessoaLicenca>().ToTable("PessoaLicenca", schemaName: "TaCertoForms");
            //-----------------------------PESSOA LICENCA----------------------------//
            //---------------------------------QUESTAO-------------------------------//
            modelBuilder.Entity<Questao>().ToTable("Questao", schemaName: "TaCertoForms");
            //---------------------------------QUESTAO-------------------------------//
            //--------------------------QUESTAO RESPOSTA ALUNO-----------------------//
            modelBuilder.Entity<QuestaoRespostaAluno>().ToTable("QuestaoRespostaAluno", schemaName: "TaCertoForms");
            //--------------------------QUESTAO RESPOSTA ALUNO-----------------------//
            //-------------------------------TIPO QUESTAO----------------------------//
            modelBuilder.Entity<TipoQuestao>().ToTable("TipoQuestao", schemaName: "TaCertoForms");
            //-------------------------------TIPO QUESTAO----------------------------//
            //----------------------------------TURMA--------------------------------//
            modelBuilder.Entity<Turma>().ToTable("Turma", schemaName: "TaCertoForms");
            //----------------------------------TURMA--------------------------------//

            //-------------------------------TURMA ALUNO-----------------------------//
            modelBuilder.Entity<TurmaAluno>().ToTable("TurmaAluno", schemaName: "TaCertoForms");
            //-------------------------------TURMA ALUNO-----------------------------//

            //-----------------------TURMA DISCIPLINA PROFESSOR----------------------//
            modelBuilder.Entity<TurmaDisciplinaProfessor>().ToTable("TurmaDisciplinaProfessor", schemaName: "TaCertoForms");
            //-----------------------TURMA DISCIPLINA PROFESSOR----------------------//



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