using System;
using System.Collections.Generic;
using TaCertoForms.Models;
namespace TaCertoForms.Models
{
    public class Fase
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Chave { get; set; }
        public int IdTipoFase { get; set; }
        public string Descricao { get; set; }

        public List<DesafioDeFaseNormal> desafiosNormal { get; set; }


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

        //public List<DesafioDeFaseAurelio> desafiosAurelio { get; set; }

        //public List<DesafioDeFaseExploradorEscolha> desafiosExploradorEscolha { get; set; }

        //public List<DesafioDeFaseExploradorColuna> desafiosExploradorColuna { get; set; }
        
    }
    
}