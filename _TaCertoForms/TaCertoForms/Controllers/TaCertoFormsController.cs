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
using Newtonsoft.Json;
using tacertoforms_dotnet.TaCertoForms.Models;

namespace tacertoforms_dotnet.Controllers{
    public class TaCertoFormsController : BaseController{
        private UsuarioManager usuarioManager = new UsuarioManager();
        private FaseManager faseManager = new FaseManager();

        private DesafioDeFaseManager desafioDeFaseManager = new DesafioDeFaseManager();
        //private FaseContexto _contexto;

        //Index: redireciona para a TelaPrincipal ou para a tela de login
        //Tipo: Redirecionador
        //OBSERVAÇÕES:
        //Estados logado = sim (redireciona para TelaPrincipal) || não (redireciona para Login)
        public IActionResult Index(){
            Start();

            if(usuarioManager.isLoged())
                return RedirectToAction("TelaPrincipal");
            else
                return RedirectToAction("Login");
        }
       
        //Login: renderiza a view do login
        //Tipo: Reder
        //OBSERVAÇÕES:
        //Estado logado = nao
        public IActionResult Login(){
            Start();

            if(usuarioManager.isLoged())
                return RedirectToAction("Index");

            return View("~/TaCertoForms/Views/Login.cshtml");
        }
        
        //Logout: realiza o logout do usuario
        //Tipo: Ação
        //OBSERVAÇÕES:
        //Lógica de logout no objeto usuario manager!
        public IActionResult Logout(){
            Start();

            usuarioManager.Logout();
            return RedirectToAction("Index");
        }
        
        //Autenticar - recebe form de login e valida autenticidade
        //Tipo: Ação
        //OBSERVAÇÕES:
        //Form - email OU login E senha
        //Melhoria - redirecionar para view login com mensagem de login e senha invalidos
        public ActionResult Autenticar(){
            Start();

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
            Start();

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
            Start();

            if(Session["tipoFase"] != null && Session["dadosParaEditar"] != null){
                @ViewBag.tipoFase = Session["tipoFase"];
                @ViewBag.dadosParaEditar = Session["dadosParaEditar"];
                Session.Remove("tipoFase");
                Session.Remove("dadosParaEditar");
            }

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
            Start();
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
            Start();
            if(!usuarioManager.isLoged())
                return RedirectToAction("Index");

            if(Session["FaseCriadaFlag"] != null && (int) Session["FaseCriadaFlag"] == 1){
                ViewBag.Toast = "Fase Normal criada com sucesso!";
                Session.Remove("FaseCriadaFlag");
            }
        
            List<Fase> listaFases = faseManager.CarregaFases();

            //string json = JsonConvert.SerializeObject(listaFases, Formatting.None);
            string json = JsonHelper.JsonSerializer<List<Fase>>(listaFases);
            
            ViewBag.listaFases = listaFases;
            ViewBag.listaFasesJson = json;
            ViewBag.HeaderTexto = "Minhas Fases";
            return View("~/TaCertoForms/Views/MinhasFases.cshtml");
        }

        //Configuracoes - configurações???
        //Tipo: Render
        //OBSERVAÇÕES:
        //Estado logado = sim
        //Precisa carregar as opções do usuario se é que essa página vai existir
        public IActionResult Configuracoes(){
            Start();
            if(!usuarioManager.isLoged())
                return RedirectToAction("Index");

            ViewBag.HeaderTexto = "Configurações";
            return View("~/TaCertoForms/Views/Configuracoes.cshtml");
        }

        //Sobre - mostra página descrevendo o tacertoforms
        //Tipo: Render
        public IActionResult Sobre(){
            Start();
            ViewBag.HeaderTexto = "Sobre";
            return View("~/TaCertoForms/Views/Sobre.cshtml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(){
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public void Start(){
            GetSession();
            usuarioManager.Session = Session;
            faseManager.Session = Session;
            desafioDeFaseManager.Session = Session;

            ViewBag.userId = Session["userId"];
            ViewBag.userName = Session["userName"];
            ViewBag.userEmail = Session["userEmail"];
        }
    }
}
