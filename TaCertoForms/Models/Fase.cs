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

        //public List<DesafioDeFaseLacuna> desafiosLacuna { get; set; }

        //public List<DesafioDeFaseAurelio> desafiosAurelio { get; set; }

        //public List<DesafioDeFaseExploradorEscolha> desafiosExploradorEscolha { get; set; }

        //public List<DesafioDeFaseExploradorColuna> desafiosExploradorColuna { get; set; }
        
    }
    
}