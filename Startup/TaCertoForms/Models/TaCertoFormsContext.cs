using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TaCertoForms.Models{
    public class TaCertoFormsContext : DbContext {
        public IConfiguration Configuration { get; set; }

        public DbSet<Atividade> Atividades { get; set; }
        public DbSet<AtividadeRespostaAluno> AtividadeRespostaAlunos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<DisciplinaTurma> DisciplinaTurmas { get; set; }
        //public DbSet<DisciplinaProfessor> DisciplinaProfessors { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Instituicao> Instituicaos { get; set; }
        public DbSet<Licenca> Licencas { get; set; }
        //public DbSet<LogLogin> LogLogins { get; set; }
        //public DbSet<Midia> Midias { get; set; }
        //public DbSet<Perfil> Perfils { get; set; }
        //public DbSet<PerfilPessoa> PerfilPessoas { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        //public DbSet<PessoaLicenca> PessoaLicencas { get; set; }
        public DbSet<Questao> Questaos { get; set; }
        //public DbSet<QuestaoRespostaAluno> QuestaoRespostaAlunos { get; set; }
        //public DbSet<TipoQuestao> TipoQuestaos { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<TurmaAluno> TurmaAlunos { get; set; }
        public DbSet<TurmaDisciplinaProfessor> TurmaDisciplinaProfessors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder){
            //optionBuilder.UseSqlServer(@"Server=localhost;Database=Startup;Trusted_Connection=True;");
            optionBuilder.UseSqlServer(@"Server=localhost\MSSQLSERVER01;Database=sesi;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            //modelBuilder.HasDefaultSchema("TaCerto");
            //-------------------------------ATIVIDADE-------------------------------
            //modelBuilder.Entity<Atividade>().ToTable("Atividade");
            //modelBuilder.Entity<Atividade>()
            //    .HasOne(a => a.TurmaDisciplinaProfessor)
            //    .WithMany(tdp => tdp.AtividadeList)
            //    .HasForeignKey(a => a.IdTurmaDisciplinaProfessor);
            //-------------------------------ATIVIDADE-------------------------------//
            //------------------------ATIVIDADE RESPOSTA ALUNO-----------------------//
            //modelBuilder.Entity<AtividadeRespostaAluno>().ToTable("AtividadeRespostaAluno");
            //modelBuilder.Entity<AtividadeRespostaAluno>()
            //    .HasOne(ara => ara.Aluno)
            //    .WithMany(a => a.AtividadeRespostaAluno)
            //    .HasForeignKey(ara => ara.IdAluno);
            //modelBuilder.Entity<AtividadeRespostaAluno>()
            //    .HasOne(ara => ara.Atividade)
            //    .WithMany(a => a.AtividadeRespostaAlunoList)
            //    .HasForeignKey(ara => ara.IdAtividade)
            //    .OnDelete(DeleteBehavior.Restrict);
            //------------------------ATIVIDADE RESPOSTA ALUNO-----------------------//
            //-------------------------------DISCIPLINA------------------------------//
            //modelBuilder.Entity<Disciplina>().ToTable("Disciplina");
            //-------------------------------DISCIPLINA------------------------------//
            //--------------------------DISCIPLINA PROFESSOR-------------------------//
            //modelBuilder.Entity<DisciplinaProfessor>().ToTable("DisciplinaProfessor");
            //--------------------------DISCIPLINA PROFESSOR-------------------------//
            //--------------------------------ENDERECO-------------------------------//
            //modelBuilder.Entity<Endereco>().ToTable("Endereco");
            //--------------------------------ENDERECO-------------------------------//
            //------------------------------INSTITUICAO------------------------------//
            //modelBuilder.Entity<Instituicao>().ToTable("Instituicao");
            //modelBuilder.Entity<Instituicao>()
            //    .HasOne(i => i.EnderecoPrincipal)
            //    .WithMany(e => e.EnderecoPrincipalList)
            //    .HasForeignKey(i => i.IdEnderecoPrincipal)
            //    .OnDelete(DeleteBehavior.Restrict);
            //modelBuilder.Entity<Instituicao>()
            //    .HasOne(i => i.EnderecoCobranca)
            //    .WithMany(e => e.EnderecoCobrancaList)
            //    .HasForeignKey(i => i.IdEnderecoCobranca)
            //    .OnDelete(DeleteBehavior.Restrict);
            //------------------------------INSTITUICAO------------------------------//
            //--------------------------------LICENCA--------------------------------//
            //modelBuilder.Entity<Licenca>().ToTable("Licenca");
            //--------------------------------LICENCA--------------------------------//
            //-------------------------------LOG LOGIN-------------------------------//
            //modelBuilder.Entity<LogLogin>().ToTable("LogLogin");
            //-------------------------------LOG LOGIN-------------------------------//
            //---------------------------------MIDIA---------------------------------//
            //modelBuilder.Entity<Midia>().ToTable("Midia");
            //---------------------------------MIDIA---------------------------------//
            //---------------------------------PERFIL--------------------------------//
            //modelBuilder.Entity<Perfil>().ToTable("Perfil");
            //---------------------------------PERFIL--------------------------------//
            //------------------------------PERFIL PESSOA----------------------------//
            //modelBuilder.Entity<PerfilPessoa>().ToTable("PerfilPessoa");
            //modelBuilder.Entity<PerfilPessoa>()
            //    .HasOne(pp => pp.Perfil)
            //    .WithMany(p => p.PerfilPessoas)
            //    .HasForeignKey(pp => pp.IdPerfil);
            //modelBuilder.Entity<PerfilPessoa>()
            //    .HasOne(pp => pp.Pessoa)
            //    .WithMany(p => p.PerfilPessoas)
            //    .HasForeignKey(pp => pp.IdPessoa);
            //------------------------------PERFIL PESSOA----------------------------//
            //---------------------------------PESSOA--------------------------------//
            //modelBuilder.Entity<Pessoa>().ToTable("Pessoa");
            //modelBuilder.Entity<Pessoa>()
            //    .HasOne(p => p.PessoaLicenca)
            //    .WithOne(pl => pl.Pessoa)
            //    .HasForeignKey<PessoaLicenca>(pl => pl.IdPessoa)
            //    .OnDelete(DeleteBehavior.Restrict);
            //---------------------------------PESSOA--------------------------------//
            //-----------------------------PESSOA LICENCA----------------------------//
            //modelBuilder.Entity<PessoaLicenca>().ToTable("PessoaLicenca");
            //modelBuilder.Entity<PessoaLicenca>()
            //    .HasOne(pl => pl.Licenca)
            //    .WithMany(l => l.PessoaLicencaList)
            //    .HasForeignKey(pl => pl.IdLicenca)
            //    .OnDelete(DeleteBehavior.Restrict);
            //-----------------------------PESSOA LICENCA----------------------------//
            //---------------------------------QUESTAO-------------------------------//
            //modelBuilder.Entity<Questao>().ToTable("Questao");
            //---------------------------------QUESTAO-------------------------------//
            //--------------------------QUESTAO RESPOSTA ALUNO-----------------------//
            //modelBuilder.Entity<QuestaoRespostaAluno>().ToTable("QuestaoRespostaAluno");
            //modelBuilder.Entity<QuestaoRespostaAluno>()
            //    .HasOne(qra => qra.Questao)
            //    .WithMany(q => q.QuestaoRespostaAlunoList)
            //    .HasForeignKey(qra => qra.IdQuestao)
            //    .OnDelete(DeleteBehavior.Restrict);
            //--------------------------QUESTAO RESPOSTA ALUNO-----------------------//
            //-------------------------------TIPO QUESTAO----------------------------//
            //modelBuilder.Entity<TipoQuestao>().ToTable("TipoQuestao");
            //-------------------------------TIPO QUESTAO----------------------------//
            //----------------------------------TURMA--------------------------------//
            //modelBuilder.Entity<Turma>().ToTable("Turma");
            //----------------------------------TURMA--------------------------------//
            //-------------------------------TURMA ALUNO-----------------------------//
            //modelBuilder.Entity<TurmaAluno>().ToTable("TurmaAluno");
            //modelBuilder.Entity<TurmaAluno>()
            //    .HasOne(ta => ta.Turma)
            //    .WithMany(t => t.TurmaAlunoList)
            //    .HasForeignKey(ta => ta.IdTurma)
            //    .OnDelete(DeleteBehavior.Restrict);
            //-------------------------------TURMA ALUNO-----------------------------//
            //-----------------------TURMA DISCIPLINA PROFESSOR----------------------//
            //modelBuilder.Entity<TurmaDisciplinaProfessor>().ToTable("TurmaDisciplinaProfessor");
            //modelBuilder.Entity<TurmaDisciplinaProfessor>()
            //    .HasOne(tdp => tdp.Turma)
            //    .WithMany(t => t.TurmaDisciplinaProfessorList)
            //    .HasForeignKey(i => i.IdTurma)
            //    .OnDelete(DeleteBehavior.Restrict);
            //-----------------------TURMA DISCIPLINA PROFESSOR----------------------//
            /*
                modelBuilder.Entity<Livro>().Property(p => p.Titulo).HasColumnType("varchar(50)");
            */
        }
    }
}