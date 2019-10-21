using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using tacertoforms.Models;
using TaCertoForms.Attributes;

namespace TaCertoForms.Controllers{
    public class ControladorBase : Controller{
        protected Context db = new Context();

        protected FlagMessage Validation([CallerMemberName] string methodName = "", [CallerFilePath] string fileName = "", [CallerLineNumber] int lineNumber = 0){
            //System.Diagnostics.Debug.WriteLine("{0}({1}):{2} - {3}", fileName, lineNumber, methodName, message);
            //var roles = this.GetType().GetMethod(methodName).GetCustomAttributes(true).OfType<RoleAttribute>()
            
            var SomenteLogado = this.GetType().GetMethod(methodName).GetCustomAttributes(true).OfType<SomenteLogadoAttribute>().SingleOrDefault();
            var roles = this.GetType().GetMethod(methodName).GetCustomAttributes(true).OfType<RoleAttribute>().SingleOrDefault();

            if(roles == null && SomenteLogado != null){
                if(Session["logado"] == null || (bool)Session["logado"] == false)
                    return new FlagMessage(false, "Usuário não está logado!");
                else
                    return new FlagMessage(true, "Válido!");
            }

            if(roles != null){
                for (int i = 0; i < roles.Value.Count; i++)
                    if(Session["role"] != null && Session["role"].ToString().ToUpper() == roles.Value[i].ToString().ToUpper())
                        return new FlagMessage(true, "Usuário possui acesso.");
            }
            else
                return new FlagMessage(true, "Usuário não precisa de acesso especial.");

            return new FlagMessage(false, "Usuário não possui acesso!");
        }

        public struct FlagMessage{
            public bool flag;
            public string msg;
            public FlagMessage(bool flag, string msg){
                this.flag = flag;
                this.msg = msg;
            }
        }
    }
}