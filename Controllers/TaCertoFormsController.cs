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

        public IActionResult Index()
        {
            bool logado = false;

            Console.WriteLine("Checa se já está logado.");

            if(!logado){
                // Não está logado, logo deve redirecionar para a página de login
                return Login();
            }else{
                // Está logago, logo deve redirecionar para a página principal
                return TelaPrincipal();
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
                Console.WriteLine(Request.Form["email"]);
                
            this.ModelState.AddModelError("", "The user name or password provided is incorrect.");

            return RedirectToAction("TelaPrincipal","TaCertoForms");
        }



        /*
        ******* Métodos para a Tela Principal *******
        */

        public IActionResult TelaPrincipal()
        {
            return View();
        }



        /*
        ******* Métodos para a Tela de Criar Fase Normal *******
        */

        public IActionResult CriarFaseNormal()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }



        /*
        ******* Métodos para a Tela de Criar Fase Lacuna *******
        */

        public IActionResult CriarFaseLacuna()
        {
            return View();
        }



        /*
        ******* Métodos para a Tela de Criar Fase Aurelio *******
        */

        public IActionResult CriarFaseAurelio()
        {
            return View();
        }



        /*
        ******* Métodos para a Tela de Criar Fase Explorador *******
        */

        public IActionResult CriarFaseExplorador()
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
