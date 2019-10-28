using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using TaCertoForms.Models;

namespace TaCertoForms.Factory{
    //CLASSE FactoryCollectionMatriz - Responsavel pelas regras de negocio de seleção do banco dedos. Essa classe pega todos os modelos relacionados a Matriz de requisição atual
    public class FactoryCollectionMatriz : IFactoryCollection{

        AtividadeMatrizCreator atividadeMatrizCreator { get; set; }
        InstituicaoMatrizCreator instituicaoMatrizCreator { get; set; }
        PessoaMatrizCreator pessoaMatrizCreator { get; set; }

        public FactoryCollectionMatriz(int IdMatriz, int IdPessoa){
            atividadeMatrizCreator = new AtividadeMatrizCreator(IdMatriz, IdPessoa);
            instituicaoMatrizCreator = new InstituicaoMatrizCreator(IdMatriz, IdPessoa);
            pessoaMatrizCreator = new PessoaMatrizCreator(IdMatriz, IdPessoa);
        }

        public List<Atividade> AtividadeList() => atividadeMatrizCreator.AtividadeList();
        public Atividade FindAtividade(int? id) => atividadeMatrizCreator.FindAtividade(id);
        public Atividade CreateAtividade(Atividade atividade) => atividadeMatrizCreator.CreateAtividade(atividade);
        public Atividade EditAtividade(Atividade atividade) => atividadeMatrizCreator.EditAtividade(atividade);
        public bool DeleteAtividade(int? id) => atividadeMatrizCreator.DeleteAtividade(id);

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
    }
}