using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using Microsoft.AspNetCore.Mvc;
using tacertoforms_dotnet.Models;
using TaCertoForms.Models;

namespace tacertoforms_dotnet.Controllers
{
    public class CriarFaseController : Controller
    {

        private Fase _fase = new Fase();
        private FaseManager _faseManager = new FaseManager();

        [HttpPost]
        public JsonResult SalvarFaseNormal([FromBody] Fase fase){
            
            if(fase != null){
                _fase = fase;
            }

            _faseManager.SalvarFaseNormal(_fase); 

            return Json(new {
                state = 0,
                msg = string.Empty
            });     
        }  
    }
}