using System;
using System.Collections.Generic;
using TaCertoForms.Models;
namespace TaCertoForms.Models
{
    public class FaseFactory{
        
        public List<Fase> GetFaseByUserId(int idUsuario){
            Fase fase1 = new Fase(), fase2 = new Fase(), fase3 = new Fase();
            List<Fase> listaDeFase = new List<Fase>();
            DesafioDeFaseNormal desafio = new DesafioDeFaseNormal();

            fase1.Id = 1;
            fase1.UsuarioId = 1;
            fase1.Chave = "XN4TG";
            fase1.IdTipoFase = 4;
            fase1.Descricao = "uma fase normal aqui";

            desafio.Id = 123;
            desafio.FaseId  = 3;
            desafio.Significado = "significado da palavra";
            desafio.Dica = "dica da palavra";
            desafio.Palavra = "Cambito";
            desafio.eCorreto = true;

            fase1.desafiosNormal = new List<DesafioDeFaseNormal>();
            fase1.desafiosNormal.Add(desafio);

            desafio = new DesafioDeFaseNormal();
            desafio.FaseId  = 3;
            desafio.Significado = "significado da palavra";
            desafio.Dica = "dica da palavra";
            desafio.Id = 124;
            desafio.Palavra = "Gambito";
            desafio.eCorreto = false;
            fase1.desafiosNormal.Add(desafio);

            desafio = new DesafioDeFaseNormal();
            desafio.FaseId  = 3;
            desafio.Significado = "significado da palavra";
            desafio.Dica = "dica da palavra";
            desafio.Id = 125;
            desafio.Palavra = "Cambitu";
            desafio.eCorreto = false;
            fase1.desafiosNormal.Add(desafio);

            desafio = new DesafioDeFaseNormal();
            desafio.FaseId  = 3;
            desafio.Significado = "significado da palavra";
            desafio.Dica = "dica da palavra";
            desafio.Id = 126;
            desafio.Palavra = "Mais";
            desafio.eCorreto = true;
            fase1.desafiosNormal.Add(desafio);

            desafio = new DesafioDeFaseNormal();
            desafio.FaseId  = 3;
            desafio.Significado = "significado da palavra";
            desafio.Dica = "dica da palavra";
            desafio.Id = 127;
            desafio.Palavra = "Mas";
            desafio.eCorreto = true;
            fase1.desafiosNormal.Add(desafio);

            desafio = new DesafioDeFaseNormal();
            desafio.FaseId  = 3;
            desafio.Significado = "significado da palavra";
            desafio.Dica = "dica da palavra";
            desafio.Id = 128;
            desafio.Palavra = "Quarenta";
            desafio.eCorreto = true;
            fase1.desafiosNormal.Add(desafio);

            desafio = new DesafioDeFaseNormal();
            desafio.FaseId  = 3;
            desafio.Significado = "significado da palavra";
            desafio.Dica = "dica da palavra";
            desafio.Id = 129;
            desafio.Palavra = "Ciquenta";
            desafio.eCorreto = false;
            fase1.desafiosNormal.Add(desafio);

            desafio = new DesafioDeFaseNormal();
            desafio.FaseId  = 3;
            desafio.Significado = "significado da palavra";
            desafio.Dica = "dica da palavra";
            desafio.Id = 130;
            desafio.Palavra = "Trinta";
            desafio.eCorreto = true;
            fase1.desafiosNormal.Add(desafio);

            desafio = new DesafioDeFaseNormal();
            desafio.FaseId  = 3;
            desafio.Significado = "significado da palavra";
            desafio.Dica = "dica da palavra";
            desafio.Id = 131;
            desafio.Palavra = "Seje";
            desafio.eCorreto = false;
            fase1.desafiosNormal.Add(desafio);

            desafio = new DesafioDeFaseNormal();
            desafio.FaseId  = 3;
            desafio.Significado = "significado da palavra";
            desafio.Dica = "dica da palavra";
            desafio.Id = 132;
            desafio.Palavra = "Menas";
            desafio.eCorreto = false;
            fase1.desafiosNormal.Add(desafio);

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

        public int getTipoFaseById(int idFase){
            int tipoFase = 0;

            if(idFase == 1){
                tipoFase = 4;
            }else if(idFase == 2){
                tipoFase = 2;
            }else if(idFase == 3){
                tipoFase = 3;
            }

            return tipoFase;
        }

        public Fase getJsonFaseById(int idFase){
            
            Fase fase = new Fase();
            DesafioDeFaseNormal desafio = new DesafioDeFaseNormal();

            fase.Id = 1;
            fase.UsuarioId = 1;
            fase.Chave = "XN4TG";
            fase.IdTipoFase = 4;
            fase.Descricao = "uma fase normal aqui";

            desafio.Id = 123;
            desafio.FaseId  = 3;
            desafio.Significado = "significado da palavra";
            desafio.Dica = "dica da palavra";
            desafio.Palavra = "Cambito";
            desafio.eCorreto = true;

            fase.desafiosNormal = new List<DesafioDeFaseNormal>();
            fase.desafiosNormal.Add(desafio);

            desafio = new DesafioDeFaseNormal();
            desafio.FaseId  = 3;
            desafio.Significado = "significado da palavra";
            desafio.Dica = "dica da palavra";
            desafio.Id = 124;
            desafio.Palavra = "Gambito";
            desafio.eCorreto = false;
            fase.desafiosNormal.Add(desafio);

            desafio = new DesafioDeFaseNormal();
            desafio.FaseId  = 3;
            desafio.Significado = "significado da palavra";
            desafio.Dica = "dica da palavra";
            desafio.Id = 125;
            desafio.Palavra = "Cambitu";
            desafio.eCorreto = false;
            fase.desafiosNormal.Add(desafio);

            desafio = new DesafioDeFaseNormal();
            desafio.FaseId  = 3;
            desafio.Significado = "significado da palavra";
            desafio.Dica = "dica da palavra";
            desafio.Id = 126;
            desafio.Palavra = "Mais";
            desafio.eCorreto = true;
            fase.desafiosNormal.Add(desafio);

            desafio = new DesafioDeFaseNormal();
            desafio.FaseId  = 3;
            desafio.Significado = "significado da palavra";
            desafio.Dica = "dica da palavra";
            desafio.Id = 127;
            desafio.Palavra = "Mas";
            desafio.eCorreto = true;
            fase.desafiosNormal.Add(desafio);

            desafio = new DesafioDeFaseNormal();
            desafio.FaseId  = 3;
            desafio.Significado = "significado da palavra";
            desafio.Dica = "dica da palavra";
            desafio.Id = 128;
            desafio.Palavra = "Quarenta";
            desafio.eCorreto = true;
            fase.desafiosNormal.Add(desafio);

            desafio = new DesafioDeFaseNormal();
            desafio.FaseId  = 3;
            desafio.Significado = "significado da palavra";
            desafio.Dica = "dica da palavra";
            desafio.Id = 129;
            desafio.Palavra = "Ciquenta";
            desafio.eCorreto = false;
            fase.desafiosNormal.Add(desafio);

            desafio = new DesafioDeFaseNormal();
            desafio.FaseId  = 3;
            desafio.Significado = "significado da palavra";
            desafio.Dica = "dica da palavra";
            desafio.Id = 130;
            desafio.Palavra = "Trinta";
            desafio.eCorreto = true;
            fase.desafiosNormal.Add(desafio);

            desafio = new DesafioDeFaseNormal();
            desafio.FaseId  = 3;
            desafio.Significado = "significado da palavra";
            desafio.Dica = "dica da palavra";
            desafio.Id = 131;
            desafio.Palavra = "Seje";
            desafio.eCorreto = false;
            fase.desafiosNormal.Add(desafio);

            desafio = new DesafioDeFaseNormal();
            desafio.FaseId  = 3;
            desafio.Significado = "significado da palavra";
            desafio.Dica = "dica da palavra";
            desafio.Id = 132;
            desafio.Palavra = "Menas";
            desafio.eCorreto = false;
            fase.desafiosNormal.Add(desafio);
            
            return fase;
           
        }
    }
}