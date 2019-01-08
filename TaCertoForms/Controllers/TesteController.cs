using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using Microsoft.AspNetCore.Mvc;
using tacertoforms_dotnet.Models;
using TaCertoForms.Models;
using Util;
using Microsoft.AspNetCore.Http;

namespace tacertoforms_dotnet.Controllers{
    public class TesteController : TesteSession{
        public TesteController() : base(){}
        public IActionResult Index(){
            return View("~/TaCertoForms/Views/Sobre.cshtml");
        }

    }
    
}