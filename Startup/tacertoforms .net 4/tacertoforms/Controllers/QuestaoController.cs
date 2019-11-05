using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using TaCertoForms.Models;
using TaCertoForms.Attributes;
using TaCertoForms.Controllers.Base;

namespace TaCertoForms.Controllers{
    [SomenteLogado]
    public class QuestaoController : ControladoraBase
    {
        [Perfil(Perfil.Autor)]
        [HttpGet]
        public JsonResult Index(int? idAtividade, int? idTipoQuestao){
            List<Questao> questao = new List<Questao>();            
            if(idAtividade == null)
                return Json(null, JsonRequestBehavior.AllowGet);
            if (idTipoQuestao != null)
                questao = Collection.FindQuestaoByTypeAndActivity(idAtividade, idTipoQuestao);
            else
                questao = Collection.FindQuestaoByTypeAndActivity(idAtividade, null);              
            return Json(questao, JsonRequestBehavior.AllowGet);
        }
        [Perfil(Perfil.Autor)]
        [HttpGet]
        public JsonResult Edit(int? id){
            Questao questao;
            if (id == null)
                return Json(null, JsonRequestBehavior.AllowGet);
            questao = Collection.FindQuestao(id);
            return Json(questao, JsonRequestBehavior.AllowGet);
        }
        [Perfil(Perfil.Autor)]
        [HttpPost]
        public JsonResult Create(Questao questao){
            if(questao.IdQuestao == 0){
                Collection.CreateQuestao(questao);
            } else {
                Collection.EditQuestao(questao);                
            }
            return Json(questao);
        }
        [Perfil(Perfil.Autor)]
        [HttpPost]
        public bool Delete(int? id){
            if(id == null) return false;
            return Collection.DeleteQuestao(id);            
        }
    }
}