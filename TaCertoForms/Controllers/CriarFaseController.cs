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

namespace tacertoforms_dotnet.Controllers
{
    public class CriarFaseController : Controller
    {
        private Dictionary<string, Object> Session { get; set; }

        private Fase _fase = new Fase();
        private FaseManager _faseManager = new FaseManager();

        /*
            Recebe "fase" que é um Json e o adiciona na FaseManager
            para a fase ser salva
         */
        [HttpPost]
        public JsonResult SalvarFaseNormal([FromBody] Fase fase){
            
            if(fase != null){
                _fase = fase;
            }

            CriarFlag("FaseCriadaFlag",1); // Cria flag para mostrar toast na próxima tela

            bool _flag = _faseManager.SalvarFaseNormal(_fase); // Adiciona a fase na _faseManager

            return Json(new {
                state = 0,
                msg = string.Empty,
                flag = _flag
            });     
        }  

        /*
         flag / Significado
            1 = Fase Normal Criada
            2 = Fase Lacuna Criada
            3 = Fase Aurelio Criada
            4 = Fase Explorador Criada
         */
        protected void CriarFlag(string nome, int flag){
            GetSession();
            try{
                Session.Add(nome, flag);

            }catch{

            }
        }

        //GetSession - verifica se client possui sessão e cria uma caso não tenha
        //Tipo: Util
        //OBSERVAÇÕES:
        //Utilidade geral que os outros metodos podem utilizar
        private void GetSession(){
            string sessionKey = Request.Cookies["tacertosessionkey"];
            if(sessionKey == null || sessionKey == "")
                sessionKey = SetSession();
            Session = MultitonSession.GetSession(sessionKey);
        }

        //SetSession - cria uma chave unica de sessão no computador do cliente
        //Tipo: Util
        //OBSERVAÇÕES:
        //Criado para extender o metodo GetSession
        private string SetSession(){
            //deletar cookies com js
            //document.cookie.split(";").forEach(function(c) { document.cookie = c.replace(/^ +/, "").replace(/=.*/, "=;expires=" + new Date().toUTCString() + ";path=/"); });
            string key = "tacertosessionkey";
            Random random = new Random();
            string value = new string(Enumerable.Repeat("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 16).Select(s => s[random.Next(s.Length)]).ToArray());

            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddDays(14);

            Response.Cookies.Append(key, value, option);

            return value;
        } 
    }
    
}