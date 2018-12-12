using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tacertoforms_dotnet.Models;

namespace tacertoforms_dotnet.Controllers
{
    public class CriarFaseNormalController : Controller
    {

         // Autentica o login do Usuário
        public IActionResult adicionar(){
            for(int i = 0; i < 50; i++)
                Console.WriteLine("Add palavra =  "+Request.Form["palavraText"]+" na fase");
                
            string temp = Request.Form["palavraText"];
            TempData["palavra"] = temp;

            return RedirectToAction("incrementaPalavrasNaTela");
        }

        // Adiciona uma tag "a" com a palavra adicionada
        // Caso o usuário clique na tag, ele poderá editá-la
        public ActionResult incrementaPalavrasNaTela(){

            return new EmptyResult();
        }
        
    }
}