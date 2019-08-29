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

            Console.WriteLine(Session["IsLogged"]);

            if(Coercion.ToBool(Session["IsLogged"]) == true){
                Session["IsLogged"] = false;
                return RedirectToAction("Privacy", "Login");
            }
            else{
                Session["IsLogged"] = true;
                return View();
            }
        }

        public IActionResult About(){
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(){
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}