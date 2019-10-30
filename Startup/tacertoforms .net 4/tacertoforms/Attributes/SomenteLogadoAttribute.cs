using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace TaCertoForms.Attributes{
    public class SomenteLogadoAttribute : ActionFilterAttribute, IAuthenticationFilter{
        public void OnAuthentication(AuthenticationContext filterContext){
            if(filterContext.HttpContext.Session["Logado"] == null || (bool)filterContext.HttpContext.Session["Logado"] == false)
                filterContext.Result = new HttpUnauthorizedResult();
        }  
        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext){
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult){
                filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary{
                    { "controller", "Login" },
                    { "action", "Index" }
                });
            }
        }
    }   
}