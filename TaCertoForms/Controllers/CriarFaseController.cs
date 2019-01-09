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

        private MultitonSession Session { get; set; }

        private Fase _fase = new Fase();
        private FaseManager _faseManager = new FaseManager();

        [HttpPost]
        public JsonResult SalvarFaseNormal([FromBody] Fase fase){
            
            if(fase != null){
                _fase = fase;
            }

            CriarFlag("FaseCriadaFlag",1);

            _faseManager.SalvarFaseNormal(_fase); 

            return Json(new {
                state = 0,
                msg = string.Empty
            });     
        }  

        protected void CriarFlag(string nome, int flag){
            GetSession();
            try{
                Session[nome] = flag;

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