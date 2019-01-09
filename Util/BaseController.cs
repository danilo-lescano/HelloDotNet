using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using Microsoft.AspNetCore.Mvc;
using tacertoforms_dotnet.Models;
using TaCertoForms.Models;
using Microsoft.AspNetCore.Http;

namespace Util{
    public class BaseController : Controller{
        protected MultitonSession Session { get; set; }

        //GetSession - verifica se client possui sessão e cria uma caso não tenha
        //Tipo: Util
        //OBSERVAÇÕES:
        //Utilidade geral que os outros metodos podem utilizar
        protected void GetSession(){
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