using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using TaCertoForms.Contexts;
using TaCertoForms.Models;

namespace TaCertoForms.Attributes {
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class PerfilAttribute : AuthorizeAttribute {
        protected List<Perfil> perfisPermitidos;

        public PerfilAttribute(params Perfil[] p) {
            perfisPermitidos = new List<Perfil>(p);
        }

        public List<Perfil> PerfisPermitidos {
            get { return perfisPermitidos; }
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext) {
           if(httpContext.Session["Logado"] == null || (bool)httpContext.Session["Logado"] == false)
                return false;
            int? id = int.Parse(Convert.ToString(httpContext.Session["IdPessoa"]));
            if(id != null)
                using(var db = new Context()) {
                    Pessoa p = db.Pessoa.Find(id);
                    foreach(var perfil in perfisPermitidos) {
                        if(perfil == p.Perfil)
                            return true;
                    }
                }
            return false;
        }
  
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext) {
            filterContext.Result = new RedirectToRouteResult(
               new RouteValueDictionary {
                    { "controller", "Login" },
                    { "action", "Index" }
               }
            );
        }

        //https://www.c-sharpcorner.com/article/custom-authorization-filter-in-mvc-with-an-example/
        //https://docs.microsoft.com/en-us/dotnet/api/system.web.mvc.filters.iauthenticationfilter?view=aspnet-mvc-5.2
        //https://docs.microsoft.com/en-us/dotnet/api/system.web.mvc.filters.iauthenticationfilter.onauthentication?view=aspnet-mvc-5.2#System_Web_Mvc_Filters_IAuthenticationFilter_OnAuthentication_System_Web_Mvc_Filters_AuthenticationContext_
        //https://docs.microsoft.com/en-us/dotnet/api/system.web.mvc.filters.authenticationcontext?view=aspnet-mvc-5.2
    }
}