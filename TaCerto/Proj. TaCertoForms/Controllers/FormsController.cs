using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaCerto.Models;

namespace TaCerto.Forms.Controllers {
    public class FormsController : ControllerBase {
        public object teste(string ac){
            Console.WriteLine(ac);
            Console.WriteLine(ac);
            Console.WriteLine(ac);
            Console.WriteLine(ac);
            Console.WriteLine(ac);
            Console.WriteLine(ac);
            Console.WriteLine(ac);
            Console.WriteLine(ac);
            IActionClass Action = (IActionClass) Activator.CreateInstance(Type.GetType(ac));
            return Action.Resposta(ac);
            //return GetAllEntities().Count;
        }
    }
}