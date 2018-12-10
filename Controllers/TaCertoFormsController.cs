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

            string view;
            if(op == 1) // Tela Minhas Fases
            {
                ViewBag.HeaderTexto = "Minhas Fases";
                view = "~/Views/TaCertoForms/MinhasFases.cshtml";
            }else if(op == 2) // Tela Configurações
            {
                ViewBag.HeaderTexto = "Configurações";
                view = "~/Views/TaCertoForms/Configuracoes.cshtml";
            }else if(op == 3) // Tela About
            {
                ViewBag.HeaderTexto = "Sobre";
                view = "~/Views/TaCertoForms/Sobre.cshtml";
            }else // Sair -> Tela de Login
                view = "~/Views/TaCertoForms/Login.cshtml";
                
            return View(view);
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
            ViewBag.HeaderTexto = "Tá Certo Forms";

            return View();
        }

        public IActionResult CriarFase(int id)
        {
            string view;
            if(id == 1){
                ViewBag.HeaderTexto = "Modo Normal";
                view = "~/Views/TaCertoForms/CriarFaseNormal.cshtml";
            }else if(id == 2){
                ViewBag.HeaderTexto = "Modo Lacuna";
                view = "~/Views/TaCertoForms/CriarFaseLacuna.cshtml";
            }
            else if(id == 3){
                ViewBag.HeaderTexto = "Modo Aurélio";
                view = "~/Views/TaCertoForms/CriarFaseAurelio.cshtml";
            }else if(id == 4){
                ViewBag.HeaderTexto = "Modo Explorador";
                view = "~/Views/TaCertoForms/CriarFaseExplorador.cshtml";
            }else 
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
            ViewBag.HeaderTexto = "Minhas Fases";
            return View();
        }




        /*
        ******* Métodos para a Tela Minhas Fases *******
        */

        public IActionResult Configuracoes()
        {
            ViewBag.HeaderTexto = "Configurações";
            return View();
        }



        /*
        ******* Métodos para a Tela Minhas Fases *******
        */

        public IActionResult Sobre()
        {
            ViewBag.HeaderTexto = "Sobre";
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
       public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
