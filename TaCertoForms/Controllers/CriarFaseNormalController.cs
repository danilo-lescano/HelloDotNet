using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using Microsoft.AspNetCore.Mvc;
using tacertoforms_dotnet.Models;
using TaCertoForms.Models;



// Macoratti
using System.Text;
using System.IO;
using System.Runtime.Serialization.Json;

namespace tacertoforms_dotnet.Controllers
{
    public class CriarFaseNormalController : Controller
    {

        private Fase _fase = new Fase();
        
        public IActionResult Index(){
            return View(_fase);
        }
        [HttpPost]
        public JsonResult SalvarFase([FromBody] Fase fase){
            
               if(fase != null){
                   _fase = fase;
               }
                for(int i = 0; i < 100; i++)
                    Console.WriteLine(_fase.Chave + "   " + _fase.desafios.First().Palavra);

               return Json(new {
                   state = 0,
                   msg = string.Empty
               });
            
        }  

        public T ConverteJSonParaObject<T>(string jsonString) {
            try{
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
                T obj = (T)serializer.ReadObject(ms);
                return obj;
            }catch{
                throw;
            }
        }

        [HttpPost]
        public ActionResult xxx([FromBody] string x){
            try{
                var body = new StreamReader(Request.Body);
                //The modelbinder has already read the stream and need to reset the stream index
                body.BaseStream.Seek(0, SeekOrigin.Begin); 
                var requestBody = body.ReadToEnd();
                //etc, we use this for an audit trail
                //dynamic x = content;
                for (int i = 0; i < 100; i++){
                    Console.WriteLine(requestBody);
                }
            }
            catch (System.Exception){
                
            }
            
            return Json(new {msg = "ok"});
        }
    }
}