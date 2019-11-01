using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaCertoForms.Models{
    [Table("Disciplina")]
    public class Disciplina {
        [Key]
        public int IdDisciplina { get; set; }
        public int IdMatriz { get; set; }
        [MaxLength(150)]
        public string Nome { get; set; }
        [MaxLength(150)]
        public string Descricao { get; set; }


        //NAVIGATION PROPERTY
        public Instituicao Matriz { get; set; }
    }
}