using System;
using System.Collections.Generic;
using TaCertoForms.Models;
namespace TaCertoForms.Models
{
    public class UsuarioManager
    {
        public Dictionary<string, string> Session { get; set; }

        public bool AutenticarLogin(string email, string senha){
            if(Session.ContainsKey("email"))
                Session.Remove("email");
            Session.Add("email", email);
            return true;
        }
    }
}