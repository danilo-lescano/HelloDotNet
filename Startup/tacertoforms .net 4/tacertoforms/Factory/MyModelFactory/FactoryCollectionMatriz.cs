using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using TaCertoForms.Models;

namespace TaCertoForms.Factory{
    //CLASSE FactoryCollectionMatriz - Responsavel pelas regras de negocio de seleção do banco dedos. Essa classe pega todos os modelos relacionados a Matriz de requisição atual
    public class FactoryCollectionMatriz : IFactoryCollection{

        AtividadeMatrizCreator atividadeMatrizCreator { get; set; }
        DisciplinaMatrizCreator disciplinaMatrizCreator { get; set; }
        EnderecoMatrizCreator enderecoMatrizCreator { get; set; }
        InstituicaoMatrizCreator instituicaoMatrizCreator { get; set; }
        PessoaMatrizCreator pessoaMatrizCreator { get; set; }
        QuestaoMatrizCreator questaoMatrizCreator { get; set; }
        TurmaMatrizCreator turmaMatrizCreator { get; set; }

        public FactoryCollectionMatriz(int IdMatriz, int IdPessoa){
            atividadeMatrizCreator = new AtividadeMatrizCreator(IdMatriz, IdPessoa);
            disciplinaMatrizCreator = new DisciplinaMatrizCreator(IdMatriz, IdPessoa);
            enderecoMatrizCreator = new EnderecoMatrizCreator(IdMatriz, IdPessoa);
            instituicaoMatrizCreator = new InstituicaoMatrizCreator(IdMatriz, IdPessoa);
            pessoaMatrizCreator = new PessoaMatrizCreator(IdMatriz, IdPessoa);
            questaoMatrizCreator = new QuestaoMatrizCreator(IdMatriz, IdPessoa);
            turmaMatrizCreator = new TurmaMatrizCreator(IdMatriz, IdPessoa);
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
    }
}