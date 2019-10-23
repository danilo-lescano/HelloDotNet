using System.Web.Mvc;
using TaCertoForms.Attributes;
using TaCertoForms.Controllers.Base;

namespace TaCertoForms.Controllers{
    [SomenteLogado]
    public class HomeController : ControladoraBase
    {
        public ActionResult Index(){
            return View();
        }

        public ActionResult About(){
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact(){
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Relatorios(){
            return View();
        }
    }
}