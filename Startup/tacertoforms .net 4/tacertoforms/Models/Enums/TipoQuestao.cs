using System.Collections.Generic;
using System.Linq;

using TaCertoForms.Contexts;
using TaCertoForms.Models;
public static class Get {
    private static Context db = new Context();
    public static List<TipoQuestao> TipoQuestoes(){
        List<TipoQuestao> tq = db.TipoQuestao.ToList();
        return tq;
    }
}