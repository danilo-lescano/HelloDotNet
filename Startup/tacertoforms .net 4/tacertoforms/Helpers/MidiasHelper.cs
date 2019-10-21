using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using tacertoforms.Models;

namespace tacertoforms.Helpers
{
    public class MidiasHelper
    {
        public static MvcHtmlString showImage(Midia midia, string id = "", string classname = "", string width = "", string height = "")
        {
            string img = "<img ";
            img += "src='" + HttpContext.Current.Request.Url.Authority + "/App_data/Upload/" + midia.Tabela + "/" + midia.IdMidia + midia.Extensao + "'";            
            img += id != "" ? "id='" + id + "'" : "";
            img += classname != "" ? "class='" + classname + "'" : "";
            img += width != "" ? "width='" + width + "'" : "";
            img += height != "" ? "height='" + height + "'" : "";
            img += "/>";
            return MvcHtmlString.Create(img);
        }
    }
}