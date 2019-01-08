using System;
using System.Collections.Generic;
using TaCertoForms.Models;
namespace TaCertoForms.Models
{
    public class FaseFactory{
        
        public List<Fase> GetFaseByUserId(int idUsuario){
            Fase fase1 = new Fase(), fase2 = new Fase(), fase3 = new Fase();
            List<Fase> listaDeFase = new List<Fase>();
            fase1.Id = 1;
            fase1.UsuarioId = 1;
            fase1.Chave = "XN4TG";
            fase1.IdTipoFase = 1;
            fase1.Descricao = "uma fase normal aqui";

            fase2.Id = 2;
            fase2.UsuarioId = 1;
            fase2.Chave = "HAHA9";
            fase2.IdTipoFase = 2;
            fase2.Descricao = "uma fase de idtipo 2";

            fase3.Id = 3;
            fase3.UsuarioId = 1;
            fase3.Chave = "XO3XO";
            fase3.IdTipoFase = 3;
            fase3.Descricao = "uma fase de idtipo 3";

            listaDeFase.Add(fase1);
            listaDeFase.Add(fase2);
            listaDeFase.Add(fase3);

            return listaDeFase;
        }

        public void SalvarFaseNormal(Fase fase){
            
        }
    }
}