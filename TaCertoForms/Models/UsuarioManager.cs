using System;
using System.Collections.Generic;
using TaCertoForms.Models;
using Util;
namespace TaCertoForms.Models{
    public class UsuarioManager{
        public Dictionary<string, Object> Session { get; set; }

        public bool AutenticarLogin(string email, string senha){
            if(Session.ContainsKey("email"))
                Session.Remove("email");
            Session.Add("email", email);
            if(!Session.ContainsKey("isLoged"))
                Session.Add("isLoged", true);
            else
                Session["isLoged"] = true;
            return true;
        }
        public bool isLoged(){
            if(Session.ContainsKey("isLoged") && (bool)Session["isLoged"])
                return true;
            return false;
        }
        public void Logout(){
            MultitonSession.DeleteSession(Session);
        }
    }
}