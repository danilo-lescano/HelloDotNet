using System;
using System.Collections.Generic;
using TaCertoForms.Models;
using Util;

namespace TaCertoForms.Models{
    public class UsuarioFactory : Factory{
        public Usuario GetByEmailAndPassword(string email, string senha){
            Query = "SELECT * FROM Usuario WHERE email LIKE '${email}' AND senha LIKE MD5('${senha}')";
            QueryExecute();

            Usuario usuario = null;
            //TODO RECOVER AN USER FROM THE DATABASE
            if(email != "" && senha != ""){
                usuario = new Usuario();
                usuario.Id = 1;
                usuario.Nome = "Fernando";
                usuario.Email = email;
                usuario.Senha = senha;
            }
            return usuario;
        }
    }
}