using System;
using System.Collections.Generic;
using System.Reflection;

namespace TaCertoForms.Attributes{

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class SomenteLogadoAttribute : Attribute {}
}