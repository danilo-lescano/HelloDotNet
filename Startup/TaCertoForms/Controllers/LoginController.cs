using System;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TaCertoForms.Models;
using TaCertoForms.Util.Session;
using TaCertoForms.Util.Coercion;

namespace TaCertoForms.Controllers{
    public class LoginController : SessionController{
        public IActionResult Index(){
            Start();
            if(isUsuarioLogado()){
                //redirecionar para admin, aluno, professor dependendo do perfil
                return RedirectToAction("Index", ((Perfil)Session["Perfil"]).Nome);
            }
            else{
                //n tem login
                return View();
            }
        }

        public IActionResult Sobre(){
            Start();
            return View();
        }

        public IActionResult Logar(){
            Start();
            if(isUsuarioLogado()){
                //redirecionar para admin, aluno, professor dependendo do perfil
                return RedirectToAction("Index", ((Perfil)Session["Perfil"]).Nome);
            }
            using(var db = new TaCertoFormsContext()){
                var email = Request.Form["email"];
                var password = Request.Form["password"];
                var pessoa = db.Pessoas
                    .Where(p => p.Email == email && p.Senha == password)
                    .ToList();
                if(pessoa != null && pessoa.Count > 0){
                    GuardarSesssao(db, pessoa[0]);
                    return RedirectToAction("Index", ((Perfil)Session["Perfil"]).Nome);
                }
            }
            return RedirectToAction("Index", "Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(){
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        private void GuardarSesssao(TaCertoFormsContext db, Pessoa p){
            Session["IsLogged"] = true; //CHANGE true
            Session["Pessoa"] = p;
            var perfilPessoa = db.PerfilPessoas
                .Where(pp => pp.IdPessoa == p.IdPessoa)
                .ToList();
            List<int> auxList = new List<int>();
            foreach(var item in perfilPessoa)
                auxList.Add(item.IdPerfil);
            var perfil = db.Perfils
                .Where(per => auxList.Contains(per.IdPerfil))
                .ToList();
            Session["Perfil"] = perfil[0];
        }
        private void Start(){
            GetSession();
        }
        private bool isUsuarioLogado(){
            if(Session["IsLogged"] != null && Coercion.ToBool(Session["IsLogged"]))
                return true;
            return false;
        }
    }
}