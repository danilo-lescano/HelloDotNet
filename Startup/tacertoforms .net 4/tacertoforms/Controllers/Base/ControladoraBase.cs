using System.Web.Mvc;
using TaCertoForms.Contexts;

namespace TaCertoForms.Controllers.Base
{
    public class ControladoraBase : Controller
    {
        protected Context db = new Context();        
    }
}