using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaCerto.Models;

namespace TaCerto.Forms.Controllers {
    public class ControllerBase : Controller {
        /*public List<Type> GetAllEntities(){
            string ControllerName = this.GetType().Name.Replace("Controller", "");
            return AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => {
                    if(!typeof(IActionClass).IsAssignableFrom(x)) return false;
                    if(x.IsInterface) return false;
                    if(x.IsAbstract) return false;
                    List<Attribute> attrs = System.Attribute.GetCustomAttributes(x).ToList();
                    if(attrs == null || attrs.Count == 0) return false;
                    foreach (Attribute attr in attrs) {
                        if (attr is AssignController) {
                            AssignController a = (AssignController)attr;
                            if(!a.PerfisPermitidos.Contains(ControllerName)) return false;
                        }
                    }
                    return true;
                })
                .Select(x => x).ToList();
        }*/

        public string GetPath(string controllerName, string viewName){
            return "~/Proj. " + controllerName + "/Views/" + viewName + ".cshtml";
        }
    }
}