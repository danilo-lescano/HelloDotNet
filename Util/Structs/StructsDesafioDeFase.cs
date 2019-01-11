using System.ComponentModel.DataAnnotations;
using Util;

namespace TaCertoForms.Models
{
    //Necessário para DesafioDeFaseAurelio
    public struct ConteudoRespostaStruct{
        int index;
        string palavra;
        bool eApendice;
        string apendice;
    }

    //Necessário para DesafioDeFaseExploradorColuna
    public struct ColunaStruct{
        int equivalente;
        bool emoji;
        string conteudo;
    }

    //Necessário para DesafioDeFaseExploradorEscolha
    public struct PalavraExWrapperStruct{
        int equivalente;
        bool emoji;
        string conteudo;
    }

    //Necessário para DesafioDeFaseLacuna
    public struct RespostaStruct{
        public string conteudo { get; set; }
        public int posicao { get; set; }
    }
    //Necessário para DesafioDeFaseLacuna
    public struct FraseXlacunaStruct{
        public bool eFrase { get; set; }
        public string conteudo { get; set; }
    }
}