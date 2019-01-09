using System;
using System.Collections.Generic;
using TaCertoForms.Models;
using Util;
namespace TaCertoForms.Models{
    public class UsuarioManager{
        public MultitonSession Session { get; set; }
        private UsuarioFactory usuarioFactory = new UsuarioFactory();
        public bool AutenticarLogin(string email, string senha){
            Usuario usuario = usuarioFactory.GetByEmailAndPassword(email, senha);
            bool isAutenticado = false;
            if(usuario != null){
                Session["usuario"] = usuario;
                Session["isLoged"] = true;
                isAutenticado = true;
            }

            return isAutenticado;
        }
        public bool isLoged(){
            bool isLoged = false;
            if(Session["isLoged"] != null && (bool)Session["isLoged"])
                isLoged = true;
            return isLoged;
        }
        public void Logout(){
            MultitonSession.RemoveSession(Session);
        }
    }
}