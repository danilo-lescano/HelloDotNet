using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaCertoForms.Models{
    [Table("TurmaAluno")]
    public class TurmaAluno{
        [Key]
        public int IdTurmaAluno { get; set; }
        public int IdTurma { get; set; }
        public int IdPessoa { get; set; }

        //NAVIGATION PROPERTY
        public Turma Turma { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}