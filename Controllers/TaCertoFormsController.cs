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
