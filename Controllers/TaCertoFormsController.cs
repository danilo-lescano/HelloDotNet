using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tacertoforms_dotnet.Models;

namespace tacertoforms_dotnet.Controllers
{
    public class TaCertoFormsController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult TelaPrincipal()
        {
            return View();
        }

        public IActionResult CriarFase(int id)
        {
            string view;
            if(id == 1)
                view = "~/Views/TaCertoForms/CriarFaseNormal.cshtml";
            else if(id == 2)
                view = "~/Views/TaCertoForms/CriarFaseLacuna.cshtml";
            else if(id == 3)
                view = "~/Views/TaCertoForms/CriarFaseAurelio.cshtml";
            else if(id == 4)
                view = "~/Views/TaCertoForms/CriarFaseExplorador.cshtml";
            else 
                return RedirectToAction("Login");

            return View(view);
        }

        

        //IFRAMES AQUI
        public IActionResult AurelioIframe()
        {
            return View("~/Views/TaCertoForms/Iframe/AurelioIframe.cshtml");
        }
        public IActionResult ExploradorIframe()
        {
            return View("~/Views/TaCertoForms/Iframe/ExploradorIframe.cshtml");
        }
        public IActionResult LacunaIframe()
        {
            return View("~/Views/TaCertoForms/Iframe/LacunaIframe.cshtml");
        }
        public IActionResult NormalIframe()
        {
            return View("~/Views/TaCertoForms/Iframe/NormalIframe.cshtml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
