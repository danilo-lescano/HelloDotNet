using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tacertoforms.Models;

namespace tacertoforms.Controllers
{
    public class LoginController : Controller
    {

        public ActionResult Index(){
            return View("Login");
        }

        public ActionResult autenticar(string login, string senha){
            System.Diagnostics.Debug.WriteLine("Vamos logar" + login + " " + senha);

            return View("CriarFaseNormal");
        }
        
    }
}
