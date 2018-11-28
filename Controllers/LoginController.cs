using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tacertoforms.Models;

namespace tacertoforms.Controllers
{
    public class LoginController : Controller
    {

        public ActionResult Index(string returnUrl = null){

            this.ViewBag.ReturnUrl = returnUrl;
            return View("Login");
        }

        public ActionResult autenticar(LoginModel model, string returnUrl){

            if(this.ModelState.IsValid && Membership.ValidateUser(model.UserName, model.Password)){
                FormsAuthentication.SetAuthCookie(model.UserName, false);
                return this.Redirect(returnUrl);
            }

            this.ModelState.AddModelError("", "The user name or password providedis incorrect.");
            return this.View(model);
        }
        
    }
}
