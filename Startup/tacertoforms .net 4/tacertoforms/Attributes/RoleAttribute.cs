using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace TaCertoForms.Attributes{

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class PerfilAttribute : AuthorizeAttribute{
        protected List<string> perfisPermitidos;
        public RoleAttribute(params string[] p) {
            perfisPermitidos = new List<string>(p);
        }

        public List<string> PerfisPermitidos {
            get { return perfisPermitidos; }
        }
        
        protected override bool AuthorizeCore(HttpContextBase httpContext){
            bool flag = false;
            var id = Convert.ToString(httpContext.Session["IdPessoa"]);
            if (!string.IsNullOrEmpty(id))
                using (var context = new Context()) {
                    var perfil_list = (from p in context.Pessoas
                                    join pp in context.PerfilPessoas on p.IdPessoa equals pp.IdPessoa
                                    join pe in context.Perfils on pe.IdPerfil equals pp.IdPerfil
                                    where p.IdPessoa == id
                                    select new {pe.Nome}).ToList();
                    foreach (var perfilP in perfisPermitidos) //perfil da pessoa
                        foreach (var perfilB in perfil_list) //perfil do banco
                            if (perfilB == perfilP) return true;
                }
            return flag;
        }
  
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
               new RouteValueDictionary
               {
                    { "controller", "Home" },
                    { "action", "UnAuthorized" }
               });
        }

        //https://www.c-sharpcorner.com/article/custom-authorization-filter-in-mvc-with-an-example/
        //https://docs.microsoft.com/en-us/dotnet/api/system.web.mvc.filters.iauthenticationfilter?view=aspnet-mvc-5.2
        //https://docs.microsoft.com/en-us/dotnet/api/system.web.mvc.filters.iauthenticationfilter.onauthentication?view=aspnet-mvc-5.2#System_Web_Mvc_Filters_IAuthenticationFilter_OnAuthentication_System_Web_Mvc_Filters_AuthenticationContext_
        //https://docs.microsoft.com/en-us/dotnet/api/system.web.mvc.filters.authenticationcontext?view=aspnet-mvc-5.2
    }
}