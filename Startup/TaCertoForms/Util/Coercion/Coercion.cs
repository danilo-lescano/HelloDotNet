using System;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace TaCertoForms.Util.Coercion{
    public static class Coercion{
        public static bool ToBool(Object obj){
            bool aux;
            if(obj == null)
                return false;
            try{
                aux = (bool)obj;
            }
            catch (InvalidCastException e){
                if (e.Data == null)
                    throw;
                else
                    return false;
            }
            return aux;
        }
    }
}