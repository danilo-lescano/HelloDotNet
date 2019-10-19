using System.ComponentModel.DataAnnotations;
//ok
namespace tacertoforms.Models {
    public class AtividadeRespostaAluno {
        [Key]
        public int IdAtividadeRespostaAluno { get; set; }
        public int IdAtividade { get; set; }
        public int IdAluno { get; set; }
        public string DataEnvio { get; set; }
        public float Nota { get; set; }
        public string TempoTotal { get; set; }
    }
}