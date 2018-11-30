using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tacertoforms.Models;

namespace tacertoforms.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult TelaPrincipal()
        {
            return View();
        }

        public IActionResult CriarFaseNormal()
        {
            bool verificado = true;

            if(verificado)
                return View();
            else
                return RedirectToAction("Login");
        }
        public IActionResult NormalIFrame()
        {
            bool verificado = true;
            if(verificado)
                return View();
            else
                return RedirectToAction("Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
