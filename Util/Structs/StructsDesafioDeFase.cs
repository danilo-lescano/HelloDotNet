namespace Util
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
        string conteudo;
        int posicao;
    }
    //Necessário para DesafioDeFaseLacuna
    public struct FraseXlacunaStruct{
        bool eFrase;
        string conteudo;
    }
}