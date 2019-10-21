using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using tacertoforms.Models;

namespace tacertoforms.Controllers{
    public class QuestaoController : Controller{
        private Context db = new Context();
        [HttpGet]
        public JsonResult Index(int? idAtividade, int? idTipoQuestao){
            List<Questao> questao = new List<Questao>();            
            if(idAtividade == null)
                return Json(null, JsonRequestBehavior.AllowGet);
            if (idTipoQuestao != null)
                questao = db.Questaos.Where(q => q.IdAtividade == idAtividade && q.IdTipoQuestao == idTipoQuestao).ToList();
            else
                questao = db.Questaos.Where(q => q.IdAtividade == idAtividade).ToList();                
            return Json(questao, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult Edit(int? id){
            Questao questao;
            if (id == null)
                return Json(null, JsonRequestBehavior.AllowGet);
            questao = db.Questaos.Find(id);
            return Json(questao, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Create(Questao questao){
            if(questao.IdQuestao == 0){
                db.Questaos.Add(questao);
                db.SaveChanges();
            }
            else{
                db.Entry(questao).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Json(questao);
        }
        [HttpPost]
        public bool Delete(int? id){
            if(id == null)
                return false;
            Questao q = db.Questaos.Find(id);
            db.Questaos.Remove(q);
            db.SaveChanges();
            return true;
        }
    }
}