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
    public class AtividadesController : Controller{
        private Context db = new Context();

        [HttpPost]
        public ActionResult Teste(ViewModelAtividade vmAtividade){
            if(vmAtividade != null && vmAtividade.Questoes != null){
                foreach (var item in vmAtividade.Questoes){
                    System.Diagnostics.Debug.WriteLine(item.Titulo);
                }
            }
            return RedirectToAction("Index");
        }

        // GET: Atividades
        public ActionResult Index(){
            return View(db.Atividades.ToList());
        }

        // GET: Atividades/Details/5
        public ActionResult Details(int? id){
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Atividade atividade = db.Atividades.Find(id);
            if (atividade == null)
                return HttpNotFound();
            return View(atividade);
        }

        // GET: Atividades/Create
        public ActionResult Create(){
            return View();
        }

        // POST: Atividades/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(ViewModelAtividade vmAtividade){
            Atividade atividade = vmAtividade.Atividade;
            db.Atividades.Add(atividade);
            db.SaveChanges();
            foreach (Questao q in vmAtividade.Questoes){
                q.IdAtividade = atividade.IdAtividade;
                db.Questaos.Add(q);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: Atividades/Edit/5
        public ActionResult Edit(int? id){
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            ViewModelAtividade vmAtividade = new ViewModelAtividade();
            vmAtividade.Atividade = db.Atividades.Find(id);
            vmAtividade.Questoes = db.Questaos.Where(q => q.IdAtividade == vmAtividade.IdAtividade).ToList();
            if(vmAtividade.Questoes == null)
                vmAtividade.Questoes = new List<Questao>();
            if (vmAtividade.IdAtividade == 0)
                return HttpNotFound();
            return View(vmAtividade);
        }

        // POST: Atividades/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit(ViewModelAtividade vmAtividade){
            Atividade atividade = vmAtividade.Atividade; 
            if(atividade != null && atividade.IdAtividade != 0){
                db.Entry(atividade).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                List<Questao> lq = db.Questaos.Where(q => q.IdAtividade == atividade.IdAtividade).ToList();
                if(lq == null) lq = new List<Questao>();
                foreach (Questao q in vmAtividade.Questoes){
                    if(q.IdQuestao == 0){
                        q.IdAtividade = atividade.IdAtividade;
                        db.Questaos.Add(q);
                        db.SaveChanges();
                    }
                    else{
                        foreach (Questao qq in lq)
                            if(qq.IdQuestao == q.IdQuestao){
                                lq.Remove(qq);
                                break;
                            }
                    }
                }
                foreach (Questao qq in lq){
                    db.Questaos.Remove(qq);
                    db.SaveChanges();   
                }

                return RedirectToAction("Index");
            }

            return View(atividade);
        }

        // GET: Atividades/Delete/5
        public ActionResult Delete(int? id){
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Atividade atividade = db.Atividades.Find(id);
            if (atividade == null)
                return HttpNotFound();
            return View(atividade);
        }

        // POST: Atividades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id){
            Atividade atividade = db.Atividades.Find(id);
            db.Atividades.Remove(atividade);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing){
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    }
}
/*
var atividade = {
    IdAtividade: 0,
    IdTurmaDisciplinaProfessor: 0,
    DataInicio: '10/10/2019',
    DataFim: '20/10/2019',
    NumeroTentativas: 10,
    IsAleatorio: true,
    IsProva: false,
    Questoes : [
        {
			IdQuestao: 0,
            IdAtividade: 0,
            IdTipoQuestao: 1,
            Titulo: 'questao numero 1',
            Enunciado: 'abcdefgh',
            JsonQuestao: 'abcdefgh',
            PesoNota: 1
		},
        {
			IdQuestao: 0,
            IdAtividade: 0,
            IdTipoQuestao: 2,
            Titulo: 'questao numero 2',
            Enunciado: 'abcdefgh',
            JsonQuestao: 'abcdefgh',
            PesoNota: 2
		}
    ]
};
function sendData(){
	var xhttp = new XMLHttpRequest();
    xhttp.open('POST', '/atividades/teste');
    xhttp.setRequestHeader('Content-type', 'application/json;charset=UTF-8');
    xhttp.onload = function () {
        //console.log(xhttp.response);
        console.log("ok");
    };
    xhttp.send(JSON.stringify(atividade));
}
sendData();
*/