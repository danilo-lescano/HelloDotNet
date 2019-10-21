using System.Collections.Generic;
using System.Linq;
using tacertoforms.Models;
public static class Get {
    private static Context db = new Context();
    public static List<TipoQuestao> TipoQuestoes(){
        List<TipoQuestao> tq = db.TipoQuestaos.ToList();
        return tq;
    }
}