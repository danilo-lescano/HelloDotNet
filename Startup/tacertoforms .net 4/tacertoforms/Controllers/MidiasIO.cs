using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using tacertoforms.Models;

namespace tacertoforms.Controllers
{
    public static class MidiasIO
    {
        private static Context db = new Context();       
                
        private static TipoMidia getTipoArquivo(string contentType)
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
        public static List<Midia> Save(HttpFileCollectionBase files, int IdOrigem, string tabela, string link = null)
        {
            List<Midia> arquivos = new List<Midia>();
            var hash = Guid.NewGuid();
            if (files != null && files.Count != 0) { 
                for (var i = 0; i < files.Count; i++)
                {
                    var file = files[i];                    
                    
                    if (file != null && file.ContentLength > 0)
                    {                    
                        Midia fileDetail = new Midia()
                        {
                            IdMidia = hash,
                            IdOrigem = IdOrigem,
                            Tabela = tabela,                        
                            Filename = Path.GetFileName(file.FileName),
                            Extensao = Path.GetExtension(Path.GetFileName(file.FileName)),
                            Tipo = getTipoArquivo(file.ContentType)                            
                        };
                        arquivos.Add(fileDetail);
                        string caminho = HttpContext.Current.Server.MapPath("~/App_Data/Upload/" + tabela + '/');

                        var path = Path.Combine(caminho, fileDetail.IdMidia + fileDetail.Extensao);
                        if (!Directory.Exists(caminho))
                        {
                            Directory.CreateDirectory(caminho);
                        }
                        file.SaveAs(path);
                        db.Midias.Add(fileDetail);
                        db.SaveChanges();                     
                    }
                }
            } else if(link != null && link != "") {
                Midia fileDetail = new Midia()
                {
                    IdMidia = hash,
                    IdOrigem = IdOrigem,
                    Tabela = tabela,
                    Filename = null,
                    Link = link,
                    Extensao = "ytb",
                    Tipo = getTipoArquivo("ytb")                                        
                };
                arquivos.Add(fileDetail);
                
                db.Midias.Add(fileDetail);
                db.SaveChanges();
            }
            return arquivos;
        }
    }
}