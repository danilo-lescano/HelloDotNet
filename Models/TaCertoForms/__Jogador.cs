using System;
using System.Collections.Generic;
namespace tacertoforms_dotnet.Models
{
    public class Jogador
    {
        private const int NUM_TYPES_CARTAS = 4;
        enum CARTA {AMARELO, AZUL, VERDE, VERMELHO};

        private int id { get; set;}
        private string nome { get; set; }
        private string email { get; set; }
        private string senha { get; set; }
        private int moedas { get; set; }
        private int experiencia { get; set; }
        private int totalAcertos { get; set; }
        private int totalEstrelas { get; set; }
        private int[] cartas { get; set; } = new int[NUM_TYPES_CARTAS];
        //private List<Conquista> listaConquistas { get; set; } = new List<Conquista>();
    }
}