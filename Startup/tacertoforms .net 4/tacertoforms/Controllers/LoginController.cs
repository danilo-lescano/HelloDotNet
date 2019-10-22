using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TaCertoForms.Models;
using TaCertoForms.Contexts;
using TaCertoForms.Attributes;

namespace TaCertoForms.Controllers{
    public class LoginController : Controller{
        Context db = new Context();
        public ActionResult Index(){
            return View();
        }

        [HttpPost]
        public ActionResult Autenticar(string email, string senha){
            Pessoa pessoa = db.Pessoas.Where(p => p.Email == email && p.Senha == senha).FirstOrDefault();

            if(pessoa == null){
                ViewBag.ToastMessage = "Senha ou login inválidos!";
                return RedirectToRoute(new RouteValueDictionary{
                    { "controller", "Login" },
                    { "action", "Index" }
               });
            }
            else{
                Instituicao instituicao = db.Instituicaos.Find(pessoa.IdInstituicao);
                Session["Logado"] = true;
                Session["IdPessoa"] = pessoa.IdPessoa;
                Session["NomeUsuario"] = pessoa.Nome;
                Session["IdInstituicao"] = pessoa.IdInstituicao;
                Session["NomeInstituicao"] = instituicao.NomeFantasia;
                return RedirectToRoute(new RouteValueDictionary{
                    { "controller", "Home" },
                    { "action", "Index" }
               });
            }
        }

        public ActionResult LogOff(){
            Session["Logado"] = null;
            Session["IdPessoa"] = null;
            Session["NomeUsuario"] = null;
            Session["IdInstituicao"] = null;
            Session["NomeInstituicao"] = null;

            return RedirectToRoute(new RouteValueDictionary{
                { "controller", "Login" },
                { "action", "Index" }
            });
        }
    }
}