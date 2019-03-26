using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using Microsoft.AspNetCore.Mvc;
using tacertoforms_dotnet.Models;
using TaCertoForms.Models;
using Util;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace tacertoforms_dotnet.Controllers{
    public class CriarFaseController : BaseController{

        private Fase _fase = new Fase();
        private FaseManager _faseManager = new FaseManager();


        /*
            Recebe "fase" que é um Json e o adiciona na FaseManager
            para a fase ser salva
         */
        [HttpPost]
        public JsonResult SalvarFaseNormal([FromBody] Fase fase){
            if(fase != null)
                _fase = fase;

            CriarFlag("FaseCriadaFlag",1); // Cria flag para mostrar toast na próxima tela
     
            bool _flag = _faseManager.SalvarFaseNormal(_fase); // Adiciona a fase na _faseManager


            return Json(new {
                id = fase != null ? fase.Id.ToString() : "null",
                usuarioId = fase != null ? fase.UsuarioId.ToString() : "null",
                chave = fase != null ? fase.Chave.ToString() : "null",
                idTipoFase = fase != null ? fase.IdTipoFase.ToString() : "null",
                descricao = fase != null ? fase.Descricao.ToString() : "null",
                serialization = fase != null ? JsonConvert.SerializeObject(fase) : "null"
            });
        }

        [HttpPost]
        public string teste([FromBody] string rawString){
            return rawString + "\n end";
/*
var json = JSON.stringify(
fase = { // Dados da fase
    id: 123,
    usuarioId: 13,
    chave: "key13",
    idTipoFase: 0,
    descricao: "duas fase",
    desafiosNormal: []
});

var xhr = new XMLHttpRequest();
xhr.open("POST", "/CriarFase/teste", true);
//xhr.setRequestHeader('Content-type','application/x-www-form-urlencoded');
xhr.setRequestHeader('Content-type','application/json');
xhr.onload = ()=>{
    console.log(xhr.response);
}
xhr.send(json);
*/
        }
        

        //Logout: realiza o logout do usuario
        //Tipo: Ação
        //OBSERVAÇÕES:
        //Lógica de logout no objeto usuario manager!
        [HttpPost]
        public JsonResult SalvarFaseLacuna([FromBody] Fase fase){
            for (int i = 0; i < 30; i++)
                if(fase != null)
                    Console.WriteLine(fase.Id);
                else
                    Console.WriteLine("fase null");

            fase.ResolveComplexLacuna();

            return Json(new {
                state = 0,
                msg = string.Empty,
                flag = true
            });
        }

        //Logout: realiza o logout do usuario
        //Tipo: Ação
        //OBSERVAÇÕES:
        //Lógica de logout no objeto usuario manager!
        [HttpPost]
        public JsonResult CarregarParaEditar([FromBody] int idFase){
           
            Start();
            int tipoFase = _faseManager.getTipoFaseById(idFase);

            Fase fase = _faseManager.getJsonFaseById(idFase);

            //string faseJson = JsonConvert.SerializeObject(fase, Formatting.None);
            string faseJson = JsonHelper.JsonSerializer<Fase>(fase);

            Session["tipoFase"] = tipoFase;
            Session["dadosParaEditar"] = faseJson;

            return Json(new {
                state = 1,
            });
        }


        //CriarFlag - salva uma flag que pode ser útil no futuro
        //Flag FaseCriadaFlag
        //    1 = Fase Normal Criada
        //    2 = Fase Lacuna Criada
        //    3 = Fase Aurelio Criada
        //    4 = Fase Explorador Criada
        protected void CriarFlag(string nome, int flag){
            try{
            GetSession();

                Session[nome] = flag;
            }catch{
                for(int i = 0; i < 100; i++)
                    Console.WriteLine("catcho aqui !!");
            }
        }

         public void Start(){
            GetSession();
            //usuarioManager.Session = Session;
            //faseManager.Session = Session;
            //desafioDeFaseManager.Session = Session;

            ViewBag.userId = Session["userId"];
            ViewBag.userName = Session["userName"];
            ViewBag.userEmail = Session["userEmail"];
        }
    }
    
}