using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;


namespace tacertoforms.Attributes
{
    public class SomenteDeslogadoAttribute : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (filterContext.HttpContext.Session["Logado"] != null && (bool)filterContext.HttpContext.Session["Logado"] && filterContext.HttpContext.Request.FilePath != "/Login/LogOff")
                filterContext.Result = new HttpUnauthorizedResult();
        }
        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary{
                    { "controller", "Home" },
                    { "action", "Index" }
                });
            }
        }
    }
}