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
                questao = db.Questao.Where(q => q.IdAtividade == idAtividade && q.IdTipoQuestao == idTipoQuestao).ToList();
            else
                questao = db.Questao.Where(q => q.IdAtividade == idAtividade).ToList();                
            return Json(questao, JsonRequestBehavior.AllowGet);
        }
        [Perfil(Perfil.Autor)]
        [HttpGet]
        public JsonResult Edit(int? id){
            Questao questao;
            if (id == null)
                return Json(null, JsonRequestBehavior.AllowGet);
            questao = db.Questao.Find(id);
            return Json(questao, JsonRequestBehavior.AllowGet);
        }
        [Perfil(Perfil.Autor)]
        [HttpPost]
        public JsonResult Create(Questao questao){
            if(questao.IdQuestao == 0){
                db.Questao.Add(questao);
                db.SaveChanges();
            }
            else{
                db.Entry(questao).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Json(questao);
        }
        [Perfil(Perfil.Autor)]
        [HttpPost]
        public bool Delete(int? id){
            if(id == null)
                return false;
            Questao q = db.Questao.Find(id);
            db.Questao.Remove(q);
            db.SaveChanges();
            return true;
        }
    }
}