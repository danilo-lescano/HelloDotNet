using System;
using System.Collections.Generic;
using TaCertoForms.Models;

namespace TaCertoForms.Factory{
    //CLASSE FactoryCollectionMatriz - Responsavel pelas regras de negocio de seleção do banco dedos. Essa classe pega todos os modelos relacionados a Matriz de requisição atual
    public class FactoryCollectionMatriz : IFactoryCollection{

        AtividadeMatrizCreator atividadeMatrizCreator { get; set; }
        DisciplinaMatrizCreator disciplinaMatrizCreator { get; set; }
        DisciplinaTurmaMatrizCreator disciplinaTurmaMatrizCreator { get; set; }
        EnderecoMatrizCreator enderecoMatrizCreator { get; set; }
        InstituicaoMatrizCreator instituicaoMatrizCreator { get; set; }
        MidiaMatrizCreator midiaMatrizCreator { get; set; }
        PessoaMatrizCreator pessoaMatrizCreator { get; set; }
        QuestaoMatrizCreator questaoMatrizCreator { get; set; }
        TurmaMatrizCreator turmaMatrizCreator { get; set; }
        TurmaAlunoMatrizCreator turmaAlunoMatrizCreator { get; set; }
        TurmaDisciplinaAutorMatrizCreator turmaDisciplinaAutorMatrizCreator { get; set; }

        public FactoryCollectionMatriz(int IdMatriz, int IdPessoa){
            atividadeMatrizCreator = new AtividadeMatrizCreator(IdMatriz, IdPessoa);
            disciplinaMatrizCreator = new DisciplinaMatrizCreator(IdMatriz, IdPessoa);
            disciplinaTurmaMatrizCreator = new DisciplinaTurmaMatrizCreator(IdMatriz, IdPessoa);
            enderecoMatrizCreator = new EnderecoMatrizCreator(IdMatriz, IdPessoa);
            instituicaoMatrizCreator = new InstituicaoMatrizCreator(IdMatriz, IdPessoa);
            midiaMatrizCreator = new MidiaMatrizCreator(IdMatriz, IdPessoa);
            pessoaMatrizCreator = new PessoaMatrizCreator(IdMatriz, IdPessoa);
            questaoMatrizCreator = new QuestaoMatrizCreator(IdMatriz, IdPessoa);
            turmaMatrizCreator = new TurmaMatrizCreator(IdMatriz, IdPessoa);
            turmaAlunoMatrizCreator = new TurmaAlunoMatrizCreator(IdMatriz, IdPessoa);
            turmaDisciplinaAutorMatrizCreator = new TurmaDisciplinaAutorMatrizCreator(IdMatriz, IdPessoa);
        }

        public List<Atividade> AtividadeList() => atividadeMatrizCreator.AtividadeList();
        public Atividade FindAtividade(int? id) => atividadeMatrizCreator.FindAtividade(id);
        public Atividade CreateAtividade(Atividade atividade) => atividadeMatrizCreator.CreateAtividade(atividade);
        public Atividade EditAtividade(Atividade atividade) => atividadeMatrizCreator.EditAtividade(atividade);
        public bool DeleteAtividade(int? id) => atividadeMatrizCreator.DeleteAtividade(id);

        public List<Disciplina> DisciplinaList() => disciplinaMatrizCreator.DisciplinaList();
        public Disciplina FindDisciplina(int? id) => disciplinaMatrizCreator.FindDisciplina(id);
        public Disciplina CreateDisciplina(Disciplina disciplina) => disciplinaMatrizCreator.CreateDisciplina(disciplina);
        public Disciplina EditDisciplina(Disciplina disciplina) => disciplinaMatrizCreator.EditDisciplina(disciplina);
        public bool DeleteDisciplina(int? id) => disciplinaMatrizCreator.DeleteDisciplina(id);

        public List<DisciplinaTurma> DisciplinaTurmaList() => disciplinaTurmaMatrizCreator.DisciplinaTurmaList();
        public DisciplinaTurma FindDisciplinaTurma(int? id) => disciplinaTurmaMatrizCreator.FindDisciplinaTurma(id);
        public DisciplinaTurma CreateDisciplinaTurma(DisciplinaTurma disciplinaTurma) => disciplinaTurmaMatrizCreator.CreateDisciplinaTurma(disciplinaTurma);
        public DisciplinaTurma EditDisciplinaTurma(DisciplinaTurma disciplinaTurma) => disciplinaTurmaMatrizCreator.EditDisciplinaTurma(disciplinaTurma);
        public bool DeleteDisciplinaTurma(int? id) => disciplinaTurmaMatrizCreator.DeleteDisciplinaTurma(id);


        public List<Endereco> EnderecoList() => enderecoMatrizCreator.EnderecoList();
        public Endereco FindEndereco(int? id) => enderecoMatrizCreator.FindEndereco(id);
        public Endereco CreateEndereco(Endereco endereco) => enderecoMatrizCreator.CreateEndereco(endereco);
        public Endereco EditEndereco(Endereco endereco) => enderecoMatrizCreator.EditEndereco(endereco);
        public bool DeleteEndereco(int? id) => enderecoMatrizCreator.DeleteEndereco(id);

        public List<Instituicao> InstituicaoList() => instituicaoMatrizCreator.InstituicaoList();
        public Instituicao FindInstituicao(int? id) => instituicaoMatrizCreator.FindInstituicao(id);
        public Instituicao CreateInstituicao(Instituicao atividade) => instituicaoMatrizCreator.CreateInstituicao(atividade);
        public Instituicao EditInstituicao(Instituicao atividade) => instituicaoMatrizCreator.EditInstituicao(atividade);
        public bool DeleteInstituicao(int? id) => instituicaoMatrizCreator.DeleteInstituicao(id);


        public Midia CreateMidia(int? IdOrigem, string Tabela, Midia midia) => midiaMatrizCreator.CreateMidia(IdOrigem, Tabela, midia);
        public bool DeleteMidia(Guid? id) => midiaMatrizCreator.DeleteMidia(id);
        public Midia EditMidia(int? IdOrigem, string Tabela, Midia midia) => midiaMatrizCreator.EditMidia(IdOrigem, Tabela, midia);
        public Midia FindMidia(int? IdOrigem, string Tabela) => midiaMatrizCreator.FindMidia(IdOrigem, Tabela);
        public bool HasPermissionMidia(int? IdOrigem, string Tabela) => midiaMatrizCreator.HasPermissionMidia(IdOrigem, Tabela);
        public List<Midia> MidiaList(int? IdOrigem, string Tabela) => midiaMatrizCreator.MidiaList(IdOrigem, Tabela);
        
        public List<Pessoa> PessoaList() => pessoaMatrizCreator.PessoaList();
        public Pessoa FindPessoa(int? id) => pessoaMatrizCreator.FindPessoa(id);
        public Pessoa CreatePessoa(Pessoa pessoa) => pessoaMatrizCreator.CreatePessoa(pessoa);
        public Pessoa EditPessoa(Pessoa pessoa) => pessoaMatrizCreator.EditPessoa(pessoa);
        public bool DeletePessoa(int? id) => pessoaMatrizCreator.DeletePessoa(id);
        
        public List<Questao> QuestaoList() => questaoMatrizCreator.QuestaoList();
        public Questao FindQuestao(int? id) => questaoMatrizCreator.FindQuestao(id);
        public Questao CreateQuestao(Questao questao) => questaoMatrizCreator.CreateQuestao(questao);
        public Questao EditQuestao(Questao questao) => questaoMatrizCreator.EditQuestao(questao);
        public bool DeleteQuestao(int? id) => questaoMatrizCreator.DeleteQuestao(id);
        
        public List<Turma> TurmaList() => turmaMatrizCreator.TurmaList();
        public Turma FindTurma(int? id) => turmaMatrizCreator.FindTurma(id);
        public Turma CreateTurma(Turma turma) => turmaMatrizCreator.CreateTurma(turma);
        public Turma EditTurma(Turma turma) => turmaMatrizCreator.EditTurma(turma);
        public bool DeleteTurma(int? id) => turmaMatrizCreator.DeleteTurma(id);

        public List<TurmaAluno> TurmaAlunoList() => turmaAlunoMatrizCreator.TurmaAlunoList();
        public TurmaAluno FindTurmaAluno(int? id) => turmaAlunoMatrizCreator.FindTurmaAluno(id);
        public TurmaAluno CreateTurmaAluno(TurmaAluno turmaAluno) => turmaAlunoMatrizCreator.CreateTurmaAluno(turmaAluno);
        public TurmaAluno EditTurmaAluno(TurmaAluno turmaAluno) => turmaAlunoMatrizCreator.EditTurmaAluno(turmaAluno);
        public bool DeleteTurmaAluno(int? id) => turmaAlunoMatrizCreator.DeleteTurmaAluno(id);

        public List<TurmaDisciplinaAutor> TurmaDisciplinaAutorList() => turmaDisciplinaAutorMatrizCreator.TurmaDisciplinaAutorList();
        public TurmaDisciplinaAutor FindTurmaDisciplinaAutor(int? id) => turmaDisciplinaAutorMatrizCreator.FindTurmaDisciplinaAutor(id);
        public TurmaDisciplinaAutor CreateTurmaDisciplinaAutor(TurmaDisciplinaAutor turmaDisciplinaAutor) => turmaDisciplinaAutorMatrizCreator.CreateTurmaDisciplinaAutor(turmaDisciplinaAutor);
        public TurmaDisciplinaAutor EditTurmaDisciplinaAutor(TurmaDisciplinaAutor turmaDisciplinaAutor) => turmaDisciplinaAutorMatrizCreator.EditTurmaDisciplinaAutor(turmaDisciplinaAutor);
        public bool DeleteTurmaDisciplinaAutor(int? id) => turmaDisciplinaAutorMatrizCreator.DeleteTurmaDisciplinaAutor(id);
    }
}