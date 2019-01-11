using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using Microsoft.AspNetCore.Mvc;
using tacertoforms_dotnet.Models;
using TaCertoForms.Models;
using Util;
using Microsoft.AspNetCore.Http;

namespace tacertoforms_dotnet.Controllers{
    public class CriarFaseController : BaseController{

        private Fase _fase = new Fase();
        private FaseManager _faseManager = new FaseManager();

        /*
            Recebe "fase" que é um Json e o adiciona na FaseManager
            para a fase ser salva
         */
        [HttpPost]
        public JsonResult SalvarFaseNormal([FromBody] Fase fase){
            if(fase != null)
                _fase = fase;

            CriarFlag("FaseCriadaFlag",1); // Cria flag para mostrar toast na próxima tela

            bool _flag = _faseManager.SalvarFaseNormal(_fase); // Adiciona a fase na _faseManager

            return Json(new {
                state = 0,
                msg = string.Empty,
                flag = _flag
            });
        }

        //Logout: realiza o logout do usuario
        //Tipo: Ação
        //OBSERVAÇÕES:
        //Lógica de logout no objeto usuario manager!
        [HttpPost]
        public JsonResult SalvarFaseLacuna([FromBody] Fase fase){
            fase.ResolveComplexLacuna();

            return Json(new {
                state = 0,
                msg = string.Empty,
                flag = true
            });
        }

        //CriarFlag - salva uma flag que pode ser útil no futuro
        //Flag FaseCriadaFlag
        //    1 = Fase Normal Criada
        //    2 = Fase Lacuna Criada
        //    3 = Fase Aurelio Criada
        //    4 = Fase Explorador Criada
        protected void CriarFlag(string nome, int flag){
            GetSession();
            try{
                Session[nome] = flag;
            }catch{}
        }
    }
    
}