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
        private Dictionary<string, Object> Session { get; set; }
        private UsuarioManager usuarioManager = new UsuarioManager();
        private FaseManager faseManager = new FaseManager();
        private DesafioDeFaseManager desafioDeFaseManager = new DesafioDeFaseManager();

        //Index: redireciona para a TelaPrincipal ou para a tela de login
        //Tipo: Redirecionador
        //OBSERVAÇÕES:
        //Estados logado = sim (redireciona para TelaPrincipal) || não (redireciona para Login)
        public IActionResult Index(){
            Session = GetSession();
            usuarioManager.Session = Session;

            if(usuarioManager.isLoged())
                return RedirectToAction("TelaPrincipal");
            else
                return RedirectToAction("Login");
        }

        //Menu: recebe uma operação(op) e redireciona para sua respectiva página
        //Tipo: Redirecionador
        //OBSERVAÇÕES:
        //Estado logado = sim
        //op = 1 - MinhasFases; op = 2 - Configuracoes; op = 3 - Sobre; op = 4 - logout; op invalido redireciona para index
        public IActionResult Menu(int op){
            Session = GetSession();
            usuarioManager.Session = Session;

            if(!usuarioManager.isLoged())
                return RedirectToAction("Index");

            if(op == 1)
                return RedirectToAction("MinhasFases");
            else if(op == 2)
                return RedirectToAction("Configuracoes");
            else if(op == 3)
                return RedirectToAction("Sobre");
            else if(op == 4)
                return RedirectToAction("Logout");
            else
                return RedirectToAction("Index");
        }
       
        //Login: renderiza a view do login
        //Tipo: Reder
        //OBSERVAÇÕES:
        //Estado logado = nao
        public IActionResult Login(){
            Session = GetSession();
            usuarioManager.Session = Session;

            if(usuarioManager.isLoged())
                return RedirectToAction("Index");

            return View("~/TaCertoForms/Views/Login.cshtml");
        }
        
        //Logout: realiza o logout do usuario
        //Tipo: Ação
        //OBSERVAÇÕES:
        //Lógica de logout no objeto usuario manager!
        public IActionResult Logout(){
            Session = GetSession();
            usuarioManager.Session = Session;

            usuarioManager.Logout();
            return RedirectToAction("Index");
        }
        
        //Autenticar - recebe form de login e valida autenticidade
        //Tipo: Ação
        //OBSERVAÇÕES:
        //Form - email OU login E senha
        //Melhoria - redirecionar para view login com mensagem de login e senha invalidos
        public ActionResult Autenticar(){
            Session = GetSession();
            usuarioManager.Session = Session;

            string email = Request.Form["email"];
            string password = Request.Form["password"];

            if(usuarioManager.AutenticarLogin(email, password))
                return RedirectToAction("TelaPrincipal","TaCertoForms");
            else
                return RedirectToAction("Index","TaCertoForms");
        }

        //TelaPrincipal - renderiza tela principal
        //Tipo: Render
        //OBSERVAÇÕES:
        //Estado logado = sim
        public IActionResult TelaPrincipal(){
           Session = GetSession();
            usuarioManager.Session = Session;

            if(!usuarioManager.isLoged())
                return RedirectToAction("Index");

            ViewBag.HeaderTexto = "Tá Certo Forms";

            return View("~/TaCertoForms/Views/TelaPrincipal.cshtml");
        }

        //CriarFase - Procura a tela de id que representa a fase pra ser criada e renderiza ela
        //Tipo: Render
        //OBSERVAÇÕES:
        //Estado logado = sim
        //Fases normal, lacuna, aurelio, explorador
        //Esse metoro é um Render, mas pode ser transformado num redirecionar caso alguma lógica mais complexa precise ser acressentada
        public IActionResult CriarFase(string fase){
            Session = GetSession();
            usuarioManager.Session = Session;

            if(!usuarioManager.isLoged())
                return RedirectToAction("Index");

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
                return RedirectToAction("Index");

            return View(view);
        }

        //ChamarIframe - renderiza uma imitação de alguma fase do TaCerto
        //Tipo: Render
        //OBSERVAÇÕES:
        //Estado logado = sim
        //Renderiza tela NormalIframe, LacunaIframe, AurelioIframe, ExploradorIframe
        //Esse método deveria ser invocado apenas ao ser carregado a fase normal. Cabe alguma validação mais interessante ou um metodo diferente do iframe usado
        public IActionResult ChamarIframe(int id){
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
                return RedirectToAction("Index");

            return View(view);
        }

        //MinhasFases - carrega as fases do usuario (banco e sessao) e renderiza elas
        //Tipo: Ação / Render
        //OBSERVAÇÕES:
        //Estado logado = sim
        public IActionResult MinhasFases(){
            Session = GetSession();
            usuarioManager.Session = Session;
            faseManager.Session = Session;
            desafioDeFaseManager.Session = Session;

            if(!usuarioManager.isLoged())
                return RedirectToAction("Index");

            if(Session.ContainsKey("FaseCriadaFlag")){
                if((int)Session["FaseCriadaFlag"] == 1){
                    ViewBag.Toast = "23523523523";
                }
            }
        
            List<Fase> listaFases = faseManager.CarregaFases();
            foreach (Fase fase in listaFases){
                List<IDesafioDeFase> listaDeDesafios = desafioDeFaseManager.CarregaDesafios(fase.Id);
                foreach (IDesafioDeFase desafio in listaDeDesafios){
                    // TO DO
                    ViewBag.HeaderTexto = "Minhas Fases";
                }
            }
            ViewBag.HeaderTexto = "Minhas Fases";
            return View("~/TaCertoForms/Views/MinhasFases.cshtml");
        }

        //Configuracoes - configurações???
        //Tipo: Render
        //OBSERVAÇÕES:
        //Estado logado = sim
        //Precisa carregar as opções do usuario se é que essa página vai existir
        public IActionResult Configuracoes(){
            ViewBag.HeaderTexto = "Configurações";
            return View("~/TaCertoForms/Views/Configuracoes.cshtml");
        }

        //Sobre - mostra página descrevendo o tacertoforms
        //Tipo: Render
        public IActionResult Sobre(){
            ViewBag.HeaderTexto = "Sobre";
            return View("~/TaCertoForms/Views/Sobre.cshtml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(){
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //GetSession - verifica se client possui sessão e cria uma caso não tenha
        //Tipo: Util
        //OBSERVAÇÕES:
        //Utilidade geral que os outros metodos podem utilizar
        private Dictionary<string, Object> GetSession(){
            string sessionKey = Request.Cookies["tacertosessionkey"];
            if(sessionKey == null || sessionKey == "")
                sessionKey = SetSession();
            return MultitonSession.GetSession(sessionKey);
        }
        //SetSession - cria uma chave unica de sessão no computador do cliente
        //Tipo: Util
        //OBSERVAÇÕES:
        //Criado para extender o metodo GetSession
        private string SetSession(){
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
