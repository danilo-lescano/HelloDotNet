using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using Microsoft.AspNetCore.Mvc;
using tacertoforms_dotnet.Models;

namespace tacertoforms_dotnet.Controllers
{
    public class CriarFaseNormalController : Controller
    {

         // Autentica o login do Usuário
        public IActionResult AdicionarDesafioDeFase(){
            for(int i = 0; i < 50; i++)
                Console.WriteLine("Add palavra =  "+Request.Form["palavraText"]+" na fase");
                
            string idFase = Request.Form["idFase"];
            TempData["palavra"] = idFase;

            return RedirectToAction("incrementaPalavrasNaTela");
        }

        // Adiciona uma tag "a" com a palavra adicionada
        // Caso o usuário clique na tag, ele poderá editá-la
        public ActionResult incrementaPalavrasNaTela(){

            return new EmptyResult();
        }

        public ActionResult xxx(){
            try
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine(Request.Form["0"]);
                    
                }
            }
            catch (System.Exception)
            {
                
            }
            
            return Json(new {msg = "ok"});
        }
    }
}