using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;

using TaCertoForms.Attributes;
using TaCertoForms.Controllers.Base;
using TaCertoForms.Models;

namespace TaCertoForms.Controllers {
    [SomenteLogado]
    public class QuestaoController : ControladoraBase {
        [HttpGet]
        [Perfil(Perfil.Autor)]
        public JsonResult Index(int? idAtividade, int? idTipoQuestao) {
            List<Questao> questao = new List<Questao>();
            if(idAtividade == null)
                return Json(null, JsonRequestBehavior.AllowGet);
            if(idTipoQuestao != null)
                questao = Collection.FindQuestaoByTypeAndActivity(idAtividade, idTipoQuestao);
            else
                questao = Collection.FindQuestaoByTypeAndActivity(idAtividade, null);
            return Json(questao, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Perfil(Perfil.Autor)]
        public JsonResult Edit(int? id) {
            Questao questao;
            if(id == null)
                return Json(null, JsonRequestBehavior.AllowGet);
            questao = Collection.FindQuestao(id);
            return Json(questao, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Perfil(Perfil.Autor)]
        public JsonResult Create(Questao questao) {
            if(questao.IdQuestao == 0)
                Collection.CreateQuestao(questao);
            else
                Collection.EditQuestao(questao);
            return Json(questao);
        }

        [HttpPost]
        [Perfil(Perfil.Autor)]
        public bool Delete(int? id) {
            if(id == null) return false;
            Questao questao = Collection.FindQuestao(id);
            if(questao == null) return false;
            List<QuestaoRespostaAluno> questaoRespostaALunoList = Collection.QuestaoRespostaAlunoList()?.Where(qra => qra.IdQuestao == id).ToList();
            if(questaoRespostaALunoList != null)
                foreach (var qra in questaoRespostaALunoList)
                    Collection.DeleteQuestaoRespostaAluno(qra.IdQuestaoRespostaAluno);
            return Collection.DeleteQuestao(id);
        }
    }
}