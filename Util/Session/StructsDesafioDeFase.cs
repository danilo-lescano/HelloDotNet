namespace Util
{
    //Necessário para DesafioDeFaseAurelio
    public struct ConteudoResposta{
        int index;
        string palavra;
        bool eApendice;
        string apendice;
    }

    //Necessário para DesafioDeFaseExploradorColuna
    public struct Coluna{
        int equivalente;
        bool emoji;
        string conteudo;
    }

    //Necessário para DesafioDeFaseExploradorEscolha
    public struct PalavraExWrapper{
        int equivalente;
        bool emoji;
        string conteudo;
    }

    //Necessário para DesafioDeFaseLacuna
    public struct Resposta{
        string conteudo;
        int posicao;
    }
    //Necessário para DesafioDeFaseLacuna
    public struct FraseXlacuna{
        bool eFrase;
        string conteudo;
    }
}