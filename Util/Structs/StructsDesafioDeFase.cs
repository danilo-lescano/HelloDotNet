using System.ComponentModel.DataAnnotations;

namespace Util
{
    //Necessário para DesafioDeFaseAurelio
    public class ConteudoRespostaStruct{
        int index;
        string palavra;
        bool eApendice;
        string apendice;
    }

    //Necessário para DesafioDeFaseExploradorColuna
    public class ColunaStruct{
        int equivalente;
        bool emoji;
        string conteudo;
    }

    //Necessário para DesafioDeFaseExploradorEscolha
    public class PalavraExWrapperStruct{
        int equivalente;
        bool emoji;
        string conteudo;
    }

    //Necessário para DesafioDeFaseLacuna
    public class RespostaStruct{
        string conteudo;
        int posicao;
    }
    //Necessário para DesafioDeFaseLacuna
    public class FraseXlacunaStruct{
        [Key]
        int idFraseXLacunaSeiLa;
        bool eFrase;
        string conteudo;
    }
}