using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

using TaCertoForms.Attributes;
using TaCertoForms.Controllers.Base;
using TaCertoForms.Models;

namespace TaCertoForms.Controllers {
    [SomenteDeslogado]
    public class LoginController : ControladoraBase {
        public ActionResult Index() {
            return View();
        }

        [HttpPost]
        public ActionResult Autenticar(string email, string senha) {
            Pessoa pessoa = db.Pessoa.Where(p => p.Email == email && p.Senha == senha).FirstOrDefault();

            if(pessoa == null) {
                ViewBag.ToastMessage = "Senha ou login inválidos!";
                return RedirectToRoute(
                    new RouteValueDictionary {
                        { "controller", "Login" },
                        { "action", "Index" }
                    }
                );
            }
            else {
                Instituicao instituicao = db.Instituicao.Find(pessoa.IdInstituicao);
                Session["Logado"] = true;
                Session["IdPessoa"] = pessoa.IdPessoa;
                Session["IdMatriz"] = GetIdMatriz(pessoa);
                Session["NomeUsuario"] = pessoa.Nome;
                Session["IdInstituicao"] = pessoa.IdInstituicao;
                Session["NomeInstituicao"] = instituicao.NomeFantasia;
                Session["Perfil"] = pessoa.Perfil;

                Midia midia = db.Midia.Where(x => x.IdOrigem == pessoa.IdPessoa && x.Tabela == "Pessoa").FirstOrDefault();
                if(midia != null)
                    Session["FotoPerfil"] = midia.Tabela + '/' + midia.IdMidia + midia.Extensao;
                return RedirectToRoute(new RouteValueDictionary {
                    { "controller", "Home" },
                    { "action", "Index" }
               });
            }
        }

        public ActionResult LogOff() {
            Session["Logado"] = null;
            Session["IdPessoa"] = null;
            Session["IdMatriz"] = null;
            Session["NomeUsuario"] = null;
            Session["IdInstituicao"] = null;
            Session["NomeInstituicao"] = null;
            Session["FotoPerfil"] = null;
            Session["Perfil"] = null;

            return RedirectToRoute(
                new RouteValueDictionary {
                    { "controller", "Login" },
                    { "action", "Index" }
                }
            );
        }

        private int GetIdMatriz(Pessoa p) {
            Instituicao i = db.Instituicao.Find(p.IdInstituicao);
            if(i.IsMatriz)
                return i.IdInstituicao;
            else {
                i = db.Instituicao.Find(i.IdMatriz);
                return i.IdInstituicao;
            }
        }
    }
}