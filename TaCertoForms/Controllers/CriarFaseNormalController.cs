using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tacertoforms_dotnet.Models;


// Macoratti
using System.Text;
using System.IO;
using System.Runtime.Serialization.Json;

namespace tacertoforms_dotnet.Controllers
{
    public class CriarFaseNormalController : Controller
    {

         // Autentica o login do Usuário
        public ActionResult SalvarFase(){
            
            try
            {               
                for(int i = 0; i < 1000; i++)
                    Console.WriteLine(Request.Form["0"]);
                    //Console.WriteLine(listaDeDesafios + "  asdas dsadasas as as asd as da ");

                return Json(new{ message = "OK"});
            }
            catch (Exception e)
            {
                for(int i = 0; i < 1000; i++)
                    Console.WriteLine(e.ToString());
                return Json(new{ message = "NOTOK"});
            }     
            
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
    }
}