using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using TaCertoForms.Models;
using TaCertoForms.Contexts;

namespace tacertoforms.Helpers{
    public class MidiasHelper{
        public static MvcHtmlString showImage(Midia midia, string id = null, string classname = null, string width = null, string height = null){
            string img = "<img ";            
            img += "src='/Content/images/upload/" + midia.Tabela + "/" + midia.IdMidia + midia.Extensao + "'";            
            img += id != null ? "id='" + id + "'" : "";
            img += classname != null ? "class='single-image " + classname + "'" : "";
            img += width != null ? "width='" + width + "'" : "";
            img += height != null  ? "height='" + height + "'" : "";
            img += "/>";            
            return MvcHtmlString.Create(img);
        }

        public static MvcHtmlString showRemoveImage(Midia midia, string icon = null, string classname = null){
            string img = "<a ";
            img += "href='/MidiasIO/Delete/" + midia.IdMidia + "'";            
            img += classname != null ? "class='btn btn-danger btn-xs btn-single-remove" + classname + "'" : "class='btn btn-danger btn-xs btn-single-remove'";
            img += icon != null ? "><i class='" + icon + "'></i>" : ">";
            img += "</a>";
            return MvcHtmlString.Create(img);            
        }
    }
}