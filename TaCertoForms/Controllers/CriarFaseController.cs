using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using Microsoft.AspNetCore.Mvc;
using tacertoforms_dotnet.Models;
using TaCertoForms.Models;



// Macoratti
using System.Text;
using System.IO;

namespace tacertoforms_dotnet.Controllers
{
    public class CriarFaseController : Controller
    {

        private Fase _fase = new Fase();

        [HttpPost]
        public JsonResult SalvarFaseNormal([FromBody] Fase fase){
            
            if(fase != null){
                _fase = fase;
            }
            
            for(int i = 0; i < 100; i++)
                Console.WriteLine(_fase.Chave + "   " + _fase.desafios[0].Palavra);

            SalvarFaseNormal 

            return Json(new {
                state = 0,
                msg = string.Empty
            });     
        }  
    }
}