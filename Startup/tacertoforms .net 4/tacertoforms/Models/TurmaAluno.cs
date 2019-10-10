using System.ComponentModel.DataAnnotations;

namespace tacertoforms.Models
{
    public class TurmaAluno
    {
        [Key]
        public int IdTurmaAluno { get; set; }
        public int IdTurma { get; set; }
        public int IdPessoa { get; set; }
    }
}