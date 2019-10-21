using System.ComponentModel.DataAnnotations;

namespace tacertoforms.Models
{
    public class TipoQuestao
    {
        [Key]
        public int IdTipoQuestao { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}