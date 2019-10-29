using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaCertoForms.Models {
        public class ViewModelInstituicao {
        //Instituicao        
        public bool EqualEnderecoCobranca { get; set; }
        public int IdInstituicao { get; set; }
        [Required(ErrorMessage = "Por favor, digite a razão social.")]
        public string RazaoSocial { get; set; }
	    public string NomeFantasia { get; set; }
	    public string CNPJ { get; set; }
	    public string Email { get; set; }
	    public string Telefone { get; set; }
	    public int IdEnderecoPrincipal { get; set; }
	    public int IdEnderecoCobranca { get; set; }
        public bool IsMatriz { get; set; }
        public int? IdMatriz { get; set; }
        //Endereço Principal
	    public string PaisPrincipal { get; set; }
	    public string UFPrincipal { get; set; }
	    public string CidadePrincipal { get; set; }
	    public int NumeroPrincipal { get; set; }
	    public string ComplementoPrincipal { get; set; }
	    public string CEPPrincipal { get; set; }
	    public string LogradouroPrincipal { get; set; }
        public string BairroPrincipal { get; set; }
        //Endereço Cobrança        
        public string PaisCobranca { get; set; }
        public string UFCobranca { get; set; }
        public string CidadeCobranca { get; set; }
        public int NumeroCobranca { get; set; }
        public string ComplementoCobranca { get; set; }
        public string CEPCobranca { get; set; }
        public string LogradouroCobranca { get; set; }
        public string BairroCobranca { get; set; }        
        public Midia Midia { get; set; }
        public Endereco enderecoPrincipal
        {
            get
            {
                return new Endereco()
                {
                    IdEndereco = this.IdEnderecoPrincipal,
                    Pais = this.PaisPrincipal,
                    UF = this.UFPrincipal,
                    Cidade = this.CidadePrincipal,
                    Numero = this.NumeroPrincipal,
                    Complemento = this.ComplementoPrincipal,
                    CEP = this.CEPPrincipal,
                    Logradouro = this.LogradouroPrincipal,
                    Bairro = this.BairroPrincipal
                };
            }
        }
        public Endereco enderecoCobranca {
            get
            {
                if (!EqualEnderecoCobranca)
                {
                    return new Endereco()
                    {
                        IdEndereco = this.IdEnderecoPrincipal == this.IdEnderecoCobranca ? 0 : this.IdEnderecoCobranca,
                        Pais = this.PaisCobranca,
                        UF = this.UFCobranca,
                        Cidade = this.CidadeCobranca,
                        Numero = this.NumeroCobranca,
                        Complemento = this.ComplementoCobranca,
                        CEP = this.CEPCobranca,
                        Logradouro = this.LogradouroCobranca,
                        Bairro = this.BairroCobranca
                    };
                }
                return null;
            }
        }
        public Instituicao instituicao
        {
            get
            {
                return new Instituicao()
                {
                    IdInstituicao = this.IdInstituicao,
                    RazaoSocial = this.RazaoSocial,
                    NomeFantasia = this.NomeFantasia,
                    CNPJ = this.CNPJ,
                    Email = this.Email,
                    Telefone = this.Telefone,
                    IdEnderecoPrincipal = this.IdEnderecoPrincipal,
                    IdEnderecoCobranca = this.IdEnderecoCobranca
                };
            }
            set
            {
                this.IdInstituicao = value.IdInstituicao;
                this.RazaoSocial = value.RazaoSocial;
                this.NomeFantasia = value.NomeFantasia;
                this.CNPJ = value.CNPJ;
                this.Email = value.Email;
                this.Telefone = value.Telefone;
                this.IdEnderecoPrincipal = value.IdEnderecoPrincipal;
                this.IdEnderecoCobranca = value.IdEnderecoCobranca;
            }
        }                    
    }
}