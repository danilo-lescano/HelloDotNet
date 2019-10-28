using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using TaCertoForms.Models;

namespace TaCertoForms.Factory{
    //CLASSE FactoryCollectionMatriz - Responsavel pelas regras de negocio de seleção do banco dedos. Essa classe pega todos os modelos relacionados a Matriz de requisição atual
    public class FactoryCollectionMatriz : IFactoryCollection{

        AtividadeMatrizCreator atividadeMatrizCreator { get; set; }
        PessoaMatrizCreator pessoaMatrizCreator { get; set; }

        public FactoryCollectionMatriz(int IdMatriz, int IdPessoa){
            atividadeMatrizCreator = new AtividadeMatrizCreator(IdMatriz, IdPessoa);
            pessoaMatrizCreator = new PessoaMatrizCreator(IdMatriz, IdPessoa);
        }

        public List<Atividade> AtividadeList() => atividadeMatrizCreator.AtividadeList();
        public Atividade FindAtividade(int? id) => atividadeMatrizCreator.FindAtividade(id);
        public Atividade CreateAtividade(int? id) => atividadeMatrizCreator.CreateAtividade(id);
        public Atividade EditAtividade(int? id) => atividadeMatrizCreator.EditAtividade(id);
        public bool DeleteAtividade(int? id) => atividadeMatrizCreator.DeleteAtividade(id);

        public List<Pessoa> PessoaList() => pessoaMatrizCreator.PessoaList();
        public Pessoa FindPessoa(int? id) => pessoaMatrizCreator.FindPessoa(id);
        public Pessoa CreatePessoa(int? id) => pessoaMatrizCreator.CreatePessoa(id);
        public Pessoa EditPessoa(int? id) => pessoaMatrizCreator.EditPessoa(id);
        public bool DeletePessoa(int? id) => pessoaMatrizCreator.DeletePessoa(id);
    }
}