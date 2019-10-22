using System.ComponentModel.DataAnnotations;

namespace TaCertoForms.Models{
    public class TipoQuestao{
        [Key]
        public int IdTipoQuestao { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}