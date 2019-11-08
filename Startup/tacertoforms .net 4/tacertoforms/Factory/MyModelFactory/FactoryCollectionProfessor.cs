using System;
using System.Web;
using System.Collections.Generic;

using TaCertoForms.Models;

namespace TaCertoForms.Factory{
    //CLASSE FactoryCollectionProfessor - Responsavel pelas regras de negocio de seleção do banco dedos. Essa classe pega todos os modelos relacionados a Professor de requisição atual
    public class FactoryCollectionProfessor : IFactoryCollection{
        AtividadeProfessorCreator atividadeProfessorCreator { get; set; }
        AtividadeRespostaAlunoProfessorCreator atividadeRespostaAlunoProfessorCreator { get; set; }
        DisciplinaProfessorCreator disciplinaProfessorCreator { get; set; }
        DisciplinaTurmaProfessorCreator disciplinaTurmaProfessorCreator { get; set; }
        EnderecoProfessorCreator enderecoProfessorCreator { get; set; }
        InstituicaoProfessorCreator instituicaoProfessorCreator { get; set; }
        MidiaProfessorCreator midiaProfessorCreator { get; set; }
        PessoaProfessorCreator pessoaProfessorCreator { get; set; }
        QuestaoProfessorCreator questaoProfessorCreator { get; set; }
        QuestaoRespostaAlunoProfessorCreator questaoRespostaAlunoProfessorCreator { get; set; }
        TurmaProfessorCreator turmaProfessorCreator { get; set; }
        TurmaAlunoProfessorCreator turmaAlunoProfessorCreator { get; set; }
        TurmaDisciplinaAutorProfessorCreator turmaDisciplinaAutorProfessorCreator { get; set; }

        public FactoryCollectionProfessor(HttpSessionStateBase session){
            atividadeProfessorCreator = new AtividadeProfessorCreator(session);
            atividadeRespostaAlunoProfessorCreator = new AtividadeRespostaAlunoProfessorCreator(session);
            disciplinaProfessorCreator = new DisciplinaProfessorCreator(session);
            disciplinaTurmaProfessorCreator = new DisciplinaTurmaProfessorCreator(session);
            enderecoProfessorCreator = new EnderecoProfessorCreator(session);
            instituicaoProfessorCreator = new InstituicaoProfessorCreator(session);
            midiaProfessorCreator = new MidiaProfessorCreator(session);
            pessoaProfessorCreator = new PessoaProfessorCreator(session);
            questaoProfessorCreator = new QuestaoProfessorCreator(session);
            questaoRespostaAlunoProfessorCreator = new QuestaoRespostaAlunoProfessorCreator(session);
            turmaProfessorCreator = new TurmaProfessorCreator(session);
            turmaAlunoProfessorCreator = new TurmaAlunoProfessorCreator(session);
            turmaDisciplinaAutorProfessorCreator = new TurmaDisciplinaAutorProfessorCreator(session);
        }

        public List<Atividade> AtividadeList() => atividadeProfessorCreator.AtividadeList();
        public Atividade FindAtividade(int? id) => atividadeProfessorCreator.FindAtividade(id);
        public Atividade CreateAtividade(Atividade atividade) => atividadeProfessorCreator.CreateAtividade(atividade);
        public Atividade EditAtividade(Atividade atividade) => atividadeProfessorCreator.EditAtividade(atividade);
        public bool DeleteAtividade(int? id) => atividadeProfessorCreator.DeleteAtividade(id);

        public List<AtividadeRespostaAluno> AtividadeRespostaAlunoList() => atividadeRespostaAlunoProfessorCreator.AtividadeRespostaAlunoList();
        public AtividadeRespostaAluno FindAtividadeRespostaAluno(int? id) => atividadeRespostaAlunoProfessorCreator.FindAtividadeRespostaAluno(id);
        public AtividadeRespostaAluno CreateAtividadeRespostaAluno(AtividadeRespostaAluno atividadeRespostaAluno) => atividadeRespostaAlunoProfessorCreator.CreateAtividadeRespostaAluno(atividadeRespostaAluno);
        public AtividadeRespostaAluno EditAtividadeRespostaAluno(AtividadeRespostaAluno atividadeRespostaAluno) => atividadeRespostaAlunoProfessorCreator.EditAtividadeRespostaAluno(atividadeRespostaAluno);
        public bool DeleteAtividadeRespostaAluno(int? id) => atividadeRespostaAlunoProfessorCreator.DeleteAtividadeRespostaAluno(id);

        public List<Disciplina> DisciplinaList() => disciplinaProfessorCreator.DisciplinaList();
        public Disciplina FindDisciplina(int? id) => disciplinaProfessorCreator.FindDisciplina(id);
        public Disciplina CreateDisciplina(Disciplina disciplina) => disciplinaProfessorCreator.CreateDisciplina(disciplina);
        public Disciplina EditDisciplina(Disciplina disciplina) => disciplinaProfessorCreator.EditDisciplina(disciplina);
        public bool DeleteDisciplina(int? id) => disciplinaProfessorCreator.DeleteDisciplina(id);
        

        public List<DisciplinaTurma> DisciplinaTurmaList() => disciplinaTurmaProfessorCreator.DisciplinaTurmaList();
        public DisciplinaTurma FindDisciplinaTurma(int? id) => disciplinaTurmaProfessorCreator.FindDisciplinaTurma(id);
        public DisciplinaTurma CreateDisciplinaTurma(DisciplinaTurma Disciplinaturma) => disciplinaTurmaProfessorCreator.CreateDisciplinaTurma(Disciplinaturma);
        public DisciplinaTurma EditDisciplinaTurma(DisciplinaTurma Disciplinaturma) => disciplinaTurmaProfessorCreator.EditDisciplinaTurma(Disciplinaturma);
        public bool DeleteDisciplinaTurma(int? id) => disciplinaTurmaProfessorCreator.DeleteDisciplinaTurma(id);


        public List<Endereco> EnderecoList() => enderecoProfessorCreator.EnderecoList();
        public Endereco FindEndereco(int? id) => enderecoProfessorCreator.FindEndereco(id);
        public Endereco CreateEndereco(Endereco endereco) => enderecoProfessorCreator.CreateEndereco(endereco);
        public Endereco EditEndereco(Endereco endereco) => enderecoProfessorCreator.EditEndereco(endereco);
        public bool DeleteEndereco(int? id) => enderecoProfessorCreator.DeleteEndereco(id);

        public List<Instituicao> InstituicaoList() => instituicaoProfessorCreator.InstituicaoList();
        public Instituicao FindInstituicao(int? id) => instituicaoProfessorCreator.FindInstituicao(id);
        public Instituicao CreateInstituicao(Instituicao atividade) => instituicaoProfessorCreator.CreateInstituicao(atividade);
        public Instituicao EditInstituicao(Instituicao atividade) => instituicaoProfessorCreator.EditInstituicao(atividade);
        public bool DeleteInstituicao(int? id) => instituicaoProfessorCreator.DeleteInstituicao(id);


        public Midia CreateMidia(int? IdOrigem, string Tabela, Midia midia) => midiaProfessorCreator.CreateMidia(IdOrigem, Tabela, midia);
        public bool DeleteMidia(Guid? id) => midiaProfessorCreator.DeleteMidia(id);
        public Midia EditMidia(int? IdOrigem, string Tabela, Midia midia) => midiaProfessorCreator.EditMidia(IdOrigem, Tabela, midia);
        public Midia FindMidia(int? IdOrigem, string Tabela) => midiaProfessorCreator.FindMidia(IdOrigem, Tabela);
        public bool HasPermissionMidia(int? IdOrigem, string Tabela) => midiaProfessorCreator.HasPermissionMidia(IdOrigem, Tabela);
        public List<Midia> MidiaList(int? IdOrigem, string Tabela) => midiaProfessorCreator.MidiaList(IdOrigem, Tabela);

        public List<Pessoa> PessoaList() => pessoaProfessorCreator.PessoaList();
        public Pessoa FindPessoa(int? id) => pessoaProfessorCreator.FindPessoa(id);
        public Pessoa CreatePessoa(Pessoa pessoa) => pessoaProfessorCreator.CreatePessoa(pessoa);
        public Pessoa EditPessoa(Pessoa pessoa) => pessoaProfessorCreator.EditPessoa(pessoa);
        public bool DeletePessoa(int? id) => pessoaProfessorCreator.DeletePessoa(id);

        public List<Questao> QuestaoList() => questaoProfessorCreator.QuestaoList();
        public Questao FindQuestao(int? id) => questaoProfessorCreator.FindQuestao(id);
        public List<Questao> FindQuestaoByTypeAndActivity(int? idAtividade, int? idTipoQuestao) => questaoProfessorCreator.FindQuestaoByTypeAndActivity(idAtividade, idTipoQuestao);
        public Questao CreateQuestao(Questao questao) => questaoProfessorCreator.CreateQuestao(questao);
        public Questao EditQuestao(Questao questao) => questaoProfessorCreator.EditQuestao(questao);
        public bool DeleteQuestao(int? id) => questaoProfessorCreator.DeleteQuestao(id);

        public List<QuestaoRespostaAluno> QuestaoRespostaAlunoList() => questaoRespostaAlunoProfessorCreator.QuestaoRespostaAlunoList();
        public QuestaoRespostaAluno FindQuestaoRespostaAluno(int? id) => questaoRespostaAlunoProfessorCreator.FindQuestaoRespostaAluno(id);
        public QuestaoRespostaAluno CreateQuestaoRespostaAluno(QuestaoRespostaAluno questaoRespostaAluno) => questaoRespostaAlunoProfessorCreator.CreateQuestaoRespostaAluno(questaoRespostaAluno);
        public QuestaoRespostaAluno EditQuestaoRespostaAluno(QuestaoRespostaAluno questaoRespostaAluno) => questaoRespostaAlunoProfessorCreator.EditQuestaoRespostaAluno(questaoRespostaAluno);
        public bool DeleteQuestaoRespostaAluno(int? id) => questaoRespostaAlunoProfessorCreator.DeleteQuestaoRespostaAluno(id);


        public List<Turma> TurmaList() => turmaProfessorCreator.TurmaList();
        public Turma FindTurma(int? id) => turmaProfessorCreator.FindTurma(id);
        public Turma CreateTurma(Turma turma) => turmaProfessorCreator.CreateTurma(turma);
        public Turma EditTurma(Turma turma) => turmaProfessorCreator.EditTurma(turma);
        public bool DeleteTurma(int? id) => turmaProfessorCreator.DeleteTurma(id);
        
        public List<TurmaAluno> TurmaAlunoList() => turmaAlunoProfessorCreator.TurmaAlunoList();
        public TurmaAluno FindTurmaAluno(int? id) => turmaAlunoProfessorCreator.FindTurmaAluno(id);
        public TurmaAluno CreateTurmaAluno(TurmaAluno turmaAluno) => turmaAlunoProfessorCreator.CreateTurmaAluno(turmaAluno);
        public TurmaAluno EditTurmaAluno(TurmaAluno turmaAluno) => turmaAlunoProfessorCreator.EditTurmaAluno(turmaAluno);
        public bool DeleteTurmaAluno(int? id) => turmaAlunoProfessorCreator.DeleteTurmaAluno(id);

        public List<TurmaDisciplinaAutor> TurmaDisciplinaAutorList() => turmaDisciplinaAutorProfessorCreator.TurmaDisciplinaAutorList();
        public TurmaDisciplinaAutor FindTurmaDisciplinaAutor(int? id) => turmaDisciplinaAutorProfessorCreator.FindTurmaDisciplinaAutor(id);
        public TurmaDisciplinaAutor CreateTurmaDisciplinaAutor(TurmaDisciplinaAutor turmaDisciplinaAutor) => turmaDisciplinaAutorProfessorCreator.CreateTurmaDisciplinaAutor(turmaDisciplinaAutor);
        public TurmaDisciplinaAutor EditTurmaDisciplinaAutor(TurmaDisciplinaAutor turmaDisciplinaAutor) => turmaDisciplinaAutorProfessorCreator.EditTurmaDisciplinaAutor(turmaDisciplinaAutor);
        public bool DeleteTurmaDisciplinaAutor(int? id) => turmaDisciplinaAutorProfessorCreator.DeleteTurmaDisciplinaAutor(id);
      
    }
}