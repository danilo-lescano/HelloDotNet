using System;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TaCertoForms.Models;
using TaCertoForms.Util.Session;
using TaCertoForms.Util.Coercion;

namespace TaCertoForms.Controllers{
    public class LoginController : SessionController{
        public IActionResult Index(){
            GetSession();
            return View();
        }

        public IActionResult About(){
            GetSession();
            return View();
        }

        public IActionResult Logar(){
            GetSession();

            Session["IsLogged"] = true;
            Session["Email"] = Request.Form["email"];
            Console.WriteLine(Session["Email"]);
            
            return RedirectToAction("Privacy", "Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(){
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}