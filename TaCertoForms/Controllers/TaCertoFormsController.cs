using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TaCertoForms.Models;
using tacertoforms_dotnet.Models;
using Util;

namespace tacertoforms_dotnet.Controllers
{
    public class TaCertoFormsController : Controller
    {
        private Dictionary<string, string> Session { get; set; }
        private UsuarioManager usuarioManager = new UsuarioManager();
        private FaseManager faseManager = new FaseManager();
        private DesafioDeFaseManager desafioDeFaseManager = new DesafioDeFaseManager();

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
            return View("~/TaCertoForms/Views/Login.cshtml");
        }

        // Autentica o login do Usuário
        public ActionResult autenticar(){
            Session = GetSession();
            usuarioManager.Session = Session;

            string email = Request.Form["email"];
            string password = Request.Form["password"];

            bool logado = usuarioManager.AutenticarLogin(email, password);
            
            if(logado)
                return RedirectToAction("TelaPrincipal","TaCertoForms");
            else
                return RedirectToAction("Login","TaCertoForms");
        }



        /*
        ******* Métodos para a Tela Principal *******
        */

        public IActionResult TelaPrincipal()
        {
           
            //ViewBag.EmailLogado = TempData["email"].ToString();
            ViewBag.HeaderTexto = "Tá Certo Forms";
            //ViewBag.OpModo = "Te";

            return View("~/TaCertoForms/Views/TelaPrincipal.cshtml");
        }

        //Procura a tela de id que representa a fase pra ser criada
        public IActionResult CriarFase(string fase)
        {
            string view;
            ViewBag.OpModo = fase;
            if(fase == "normal"){
                ViewBag.HeaderTexto = "Modo Normal";
                view = "~/TaCertoForms/Views/CriarFaseNormal.cshtml";
            }
            else if(fase == "lacuna"){
                ViewBag.HeaderTexto = "Modo Lacuna";
                view = "~/TaCertoForms/Views/CriarFaseLacuna.cshtml";
            }
            else if(fase == "aurelio"){
                ViewBag.HeaderTexto = "Modo Aurélio";
                view = "~/TaCertoForms/Views/CriarFaseAurelio.cshtml";
            }
            else if(fase == "explorador"){
                ViewBag.HeaderTexto = "Modo Explorador";
                view = "~/TaCertoForms/Views/CriarFaseExplorador.cshtml";
            }
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
                view = "~/TaCertoForms/Views/Iframe/NormalIframe.cshtml";
            else if(id == 2)
                view = "~/TaCertoForms/Views/Iframe/LacunaIframe.cshtml";
            else if(id == 3)
                view = "~/TaCertoForms/Views/Iframe/AurelioIframe.cshtml";
            else if(id == 4)
                view = "~/TaCertoForms/Views/Iframe/ExploradorIframe.cshtml";
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
            return View("~/TaCertoForms/Views/MinhasFases.cshtml");
        }




        /*
        ******* Métodos para a Tela Minhas Fases *******
        */

        public IActionResult Configuracoes()
        {
            ViewBag.HeaderTexto = "Configurações";
            return View("~/TaCertoForms/Views/Configuracoes.cshtml");
        }



        /*
        ******* Métodos para a Tela Minhas Fases *******
        */

        public IActionResult Sobre()
        {
            Session = GetSession();

            if(Session.ContainsKey("email"))
                ViewData["email"] = Session["email"];

            ViewBag.HeaderTexto = "Sobre";
                
            return View("~/TaCertoForms/Views/Sobre.cshtml");
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private Dictionary<string, string> GetSession(){
            string sessionKey = Request.Cookies["tacertosessionkey"];
            if(sessionKey == null || sessionKey == ""){
                sessionKey = SetSession();
            }
            return MultitonSession.GetSession(sessionKey);
        }
        private string SetSession()  
        {
            //deletar cookies com js
            //document.cookie.split(";").forEach(function(c) { document.cookie = c.replace(/^ +/, "").replace(/=.*/, "=;expires=" + new Date().toUTCString() + ";path=/"); });
            string key = "tacertosessionkey";
            Random random = new Random();
            string value = new string(Enumerable.Repeat("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 16).Select(s => s[random.Next(s.Length)]).ToArray());

            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddDays(14);

            Response.Cookies.Append(key, value, option);

            return value;
        }
    }
}
