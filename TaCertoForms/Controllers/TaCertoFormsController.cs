using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaCertoForms.Models;
using tacertoforms_dotnet.Models;

namespace tacertoforms_dotnet.Controllers
{
    public class TaCertoFormsController : Controller
    {

        public IActionResult Index()
        {
            bool logado = false;

            Console.WriteLine("Checa se já está logado.");

            if(!logado){
                // Não está logado, logo deve redirecionar para a página de login
                return RedirectToAction("Login");
            }else{
                // Está logago, logo deve redirecionar para a página principal
                return RedirectToAction("TelaPrincipal");
            }
        }

        public IActionResult Menu(int op){
            if(op == 1){ // Tela Minhas Fases
                return RedirectToAction("MinhasFases");
            }else if(op == 2){ // Tela Configurações
                return RedirectToAction("Configuracoes");
            }else if(op == 3){ // Tela About
                return RedirectToAction("Sobre");
            }else{ // Sair -> Tela de Login
                return RedirectToAction("Login");
            }
        }


        /*
        ******* Métodos para a Tela de Login *******
        */
       
        // Mostra a tela de Login
        public IActionResult Login()
        {

            return View();
        }

        // Autentica o login do Usuário
        public ActionResult autenticar(){
            for(int i = 0; i < 50; i++)
                Console.WriteLine("Tenho que autenticar a seguinte pessoa: "+Request.Form["email"]);
                
            //string temp = Request.Form["email"];
            //TempData["email"] = temp;

            return RedirectToAction("TelaPrincipal","TaCertoForms");
        }



        /*
        ******* Métodos para a Tela Principal *******
        */

        public IActionResult TelaPrincipal()
        {
           
            //ViewBag.EmailLogado = TempData["email"].ToString();

            return View();
        }

        //Procura a tela de id que representa a fase pra ser criada
        public IActionResult CriarFase(string fase)
        {
            string view;
            if(fase == "normal")
                view = "~/Views/TaCertoForms/CriarFaseNormal.cshtml";
            else if(fase == "lacuna")
                view = "~/Views/TaCertoForms/CriarFaseLacuna.cshtml";
            else if(fase == "aurelio")
                view = "~/Views/TaCertoForms/CriarFaseAurelio.cshtml";
            else if(fase == "explorador")
                view = "~/Views/TaCertoForms/CriarFaseExplorador.cshtml";
            else 
                return RedirectToAction("Login");

            return View(view);
        }







        /*
        ******* Métodos incializar os iframes *******
        */
        public IActionResult ChamarIframe(int id)
        {
            string view;
            if(id == 1)
                view = "~/Views/TaCertoForms/Iframe/NormalIframe.cshtml";
            else if(id == 2)
                view = "~/Views/TaCertoForms/Iframe/LacunaIframe.cshtml";
            else if(id == 3)
                view = "~/Views/TaCertoForms/Iframe/AurelioIframe.cshtml";
            else if(id == 4)
                view = "~/Views/TaCertoForms/Iframe/ExploradorIframe.cshtml";
            else 
                return RedirectToAction("Login");

            return View(view);
        }

        /*
        ******* Métodos para a Tela Minhas Fases *******
        */

        public IActionResult MinhasFases()
        {
            return View();
        }




        /*
        ******* Métodos para a Tela Minhas Fases *******
        */

        public IActionResult Configuracoes()
        {
            return View();
        }



        /*
        ******* Métodos para a Tela Minhas Fases *******
        */

        public IActionResult Sobre()
        {
            return View();
        }







        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
         public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
