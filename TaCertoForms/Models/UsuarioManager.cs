using System;
using System.Collections.Generic;
using TaCertoForms.Models;
using Util;
namespace TaCertoForms.Models{
    public class UsuarioManager{
        public Dictionary<string, Object> Session { get; set; }
        private UsuarioFactory usuarioFactory = new UsuarioFactory();
        public bool AutenticarLogin(string email, string senha){
            Usuario usuario = usuarioFactory.GetByEmailAndPassword(email, senha);
            bool isAutenticado = false;
            if(usuario != null){
                if(!Session.ContainsKey("usuario"))
                    Session.Add("usuario", usuario);
                else
                    Session["usuario"] = usuario;

                if(!Session.ContainsKey("isLoged"))
                    Session.Add("isLoged", true);
                else
                    Session["isLoged"] = true;
                isAutenticado = true;
            }

            return isAutenticado;
        }
        public bool isLoged(){
            bool isLoged = false;
            if(Session.ContainsKey("isLoged") && (bool)Session["isLoged"])
                isLoged = true;
            return isLoged;
        }
        public void Logout(){
            MultitonSession.DeleteSession(Session);
        }
    }
}