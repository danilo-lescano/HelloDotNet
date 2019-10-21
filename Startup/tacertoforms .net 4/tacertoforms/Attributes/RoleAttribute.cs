using System;
using System.Collections.Generic;
using System.Reflection;

namespace TaCertoForms.Attributes{

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class RoleAttribute : Attribute {
        protected List<string> value;
        public RoleAttribute(params string[] v) {
            value = new List<string>(v);
        }

        public List<string> Value {
            get { return value; }
        }
    }
}