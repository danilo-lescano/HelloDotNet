using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using TaCertoForms.Models;
using TaCertoForms.Contexts;
using TaCertoForms.Controllers.Base;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TaCertoForms.Attributes;
using System.Threading.Tasks;

namespace TaCertoForms.Controllers
{
    public class MidiasController : ControladoraBase {        
        private TipoMidia GetTipoArquivo(string contentType)
        {
            switch (contentType)
            {
                case "image/png":
                    return TipoMidia.Imagem;
                case "ytb":
                    return TipoMidia.YouTube;
                default: return TipoMidia.Indefinido;
            }
        }
        //public List<Midia> Save(HttpFileCollectionBase files, int IdOrigem, string tabela, string link = null)
        //{
        [HttpPost]
        public async Task<JsonResult> Save(int id, string tabela) {
            try
            {
                List<Midia> arquivos = new List<Midia>();

                var hash = Guid.NewGuid();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];
                    if (file != null && file.ContentLength > 0)
                    {
                        Midia fileDetail = new Midia()
                        {
                            IdMidia = hash,
                            IdOrigem = id,
                            Tabela = tabela,
                            Filename = Path.GetFileName(file.FileName),
                            Extensao = Path.GetExtension(Path.GetFileName(file.FileName)),
                            Tipo = GetTipoArquivo(file.ContentType)
                        };
                        arquivos.Add(fileDetail);
                        string caminho = System.Web.HttpContext.Current.Server.MapPath("~/Content/images/upload/" + tabela + '/');

                        var path = Path.Combine(caminho, fileDetail.IdMidia + fileDetail.Extensao);
                        if (!Directory.Exists(caminho))
                        {
                            Directory.CreateDirectory(caminho);
                        }
                        file.SaveAs(path);
                        db.Midia.Add(fileDetail);
                        db.SaveChanges();
                    }
                }
                return Json(arquivos);
            }
            catch (Exception)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Erro no upload");
            }
            
            /*
            else if (link != null && link != "")
            {
                Midia fileDetail = new Midia()
                {
                    IdMidia = hash,
                    IdOrigem = IdOrigem,
                    Tabela = tabela,
                    Filename = null,
                    Link = link,
                    Extensao = "ytb",
                    Tipo = GetTipoArquivo("ytb")
                };
                arquivos.Add(fileDetail);

                db.Midia.Add(fileDetail);
                db.SaveChanges();
            }
            */
            //return arquivos;


        }

        public bool Delete(Guid id)
        {
            Midia midia = db.Midia.Find(id);
            if (midia != null)
            {
               //Deletando arquivo
                var path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Content/images/upload/" + midia.Tabela + '/'), midia.IdMidia + midia.Extensao);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                db.Midia.Remove(midia);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}