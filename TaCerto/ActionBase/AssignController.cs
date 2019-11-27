using System;
using System.Collections.Generic;
using System.Web;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class AssignController : Attribute{
    protected List<string> perfisPermitidos;

    public AssignController(params string[] p) {
        perfisPermitidos = new List<string>(p);
    }

    public List<string> PerfisPermitidos {
        get { return perfisPermitidos; }
    }
}