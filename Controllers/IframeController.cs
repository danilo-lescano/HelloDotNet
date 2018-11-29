using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tacertoforms.Models;

namespace tacertoforms.Controllers
{
    public class IframeController : Controller
    {

        public IActionResult NormalIFrame()
        {
            return View("~/Views/Iframe/NormalIFrame.cshtml", "~/Views/Iframe/_Layout.cshtml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
