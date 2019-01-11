using System;
using System.Collections.Generic;
using TaCertoForms.Models;
namespace TaCertoForms.Models{
    public class Fase{
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Chave { get; set; }
        public int IdTipoFase { get; set; }
        public string Descricao { get; set; }


        //AURELIO
        public List<DesafioDeFaseAurelio> desafiosAurelio { get; set; }
        public List<int> ConteudoRespostaNum { get; set; } = new List<int>();
        public List<ConteudoRespostaStruct> ConteudoResposta { get; set; } = new List<ConteudoRespostaStruct>();
        public void ResolveComplexAurelio(){
            for (int i = 0; i < desafiosAurelio.Count; i++){
                List<ConteudoRespostaStruct> conteudoResposta = new List<ConteudoRespostaStruct>();
                for (int j = 0; j < ConteudoRespostaNum[i]; j++){
                    conteudoResposta.Add(ConteudoResposta[0]);
                    ConteudoResposta.Remove(ConteudoResposta[0]);
                }
                desafiosAurelio[i].ConteudoResposta = conteudoResposta;
            }
        }

        //EXPLORADOR COLUNA
        public List<DesafioDeFaseExploradorColuna> desafiosExploradorColuna { get; set; }
        public List<int> Coluna1Num { get; set; } = new List<int>();
        public List<ColunaStruct> Coluna1 { get; set; } = new List<ColunaStruct>();
        public List<int> Coluna2Num { get; set; } = new List<int>();
        public List<ColunaStruct> Coluna2 { get; set; } = new List<ColunaStruct>();
        public void ResolveComplexExploradorColuna(){
            for (int i = 0; i < desafiosExploradorColuna.Count; i++){
                List<ColunaStruct> coluna1 = new List<ColunaStruct>();
                for (int j = 0; j < Coluna1Num[i]; j++){
                    coluna1.Add(Coluna1[0]);
                    Coluna1.Remove(Coluna1[0]);
                }
                desafiosExploradorColuna[i].Coluna1 = coluna1;

                List<ColunaStruct> coluna2 = new List<ColunaStruct>();
                for (int j = 0; j < Coluna2Num[i]; j++){
                    coluna2.Add(Coluna2[0]);
                    Coluna2.Remove(Coluna2[0]);
                }
                desafiosExploradorColuna[i].Coluna2 = coluna2;
            }
        }

        //EXPLORADOR ESCOLHA
        public List<DesafioDeFaseExploradorEscolha> desafiosExploradorEscolha { get; set; }
        public List<int> PalavraExWrapperNum { get; set; } = new List<int>();
        public List<PalavraExWrapperStruct> PalavraExWrapper { get; set; } = new List<PalavraExWrapperStruct>();
        public void ResolveComplexExploradorEscolha(){
            for (int i = 0; i < desafiosExploradorEscolha.Count; i++){
                List<PalavraExWrapperStruct> palavraExWrapper = new List<PalavraExWrapperStruct>();
                for (int j = 0; j < PalavraExWrapperNum[i]; j++){
                    palavraExWrapper.Add(PalavraExWrapper[0]);
                    PalavraExWrapper.Remove(PalavraExWrapper[0]);
                }
                desafiosExploradorEscolha[i].PalavraExWrapper = palavraExWrapper;
            }
        }

        //LACUNA
        public List<DesafioDeFaseLacuna> desafiosLacuna { get; set; } = new List<DesafioDeFaseLacuna>();
        public List<int> RespostaNum { get; set; } = new List<int>();
        public List<RespostaStruct> Resposta { get; set; } = new List<RespostaStruct>();
        public List<int> FraseXlacunaNum { get; set; } = new List<int>();
        public List<FraseXlacunaStruct> FraseXlacuna { get; set; } = new List<FraseXlacunaStruct>();
        public void ResolveComplexLacuna(){
            for (int i = 0; i < desafiosLacuna.Count; i++){
                List<RespostaStruct> resposta = new List<RespostaStruct>();
                for (int j = 0; j < RespostaNum[i]; j++){
                    resposta.Add(Resposta[0]);
                    Resposta.Remove(Resposta[0]);
                }
                desafiosLacuna[i].Resposta = resposta;

                List<FraseXlacunaStruct> fraseXlacuna = new List<FraseXlacunaStruct>();
                for (int j = 0; j < FraseXlacunaNum[i]; j++){
                    fraseXlacuna.Add(FraseXlacuna[0]);
                    FraseXlacuna.Remove(FraseXlacuna[0]);
                }
                desafiosLacuna[i].FraseXlacuna = fraseXlacuna;
            }
        }

        //NORMAL
        public List<DesafioDeFaseNormal> desafiosNormal { get; set; }        
    }
    
}