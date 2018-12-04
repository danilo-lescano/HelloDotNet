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

        public IActionResult CriarFaseNormal()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult CriarFaseLacuna()
        {
            return View();
        }

        public IActionResult CriarFaseAurelio()
        {
            return View();
        }

        public IActionResult CriarFaseExplorador()
        {
            return View();
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
