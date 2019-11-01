using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaCertoForms.Models{
    [Table("TurmaDisciplinaAutor")]
    public class TurmaDisciplinaAutor{
        [Key]
        public int IdTurmaDisciplinaAutor { get; set; }
        public int IdAutor { get; set; }
        public int IdDisciplinaTurma { get; set; }       

        //NAVIGATION PROPERTY
        public Pessoa Autor { get; set; }
        public DisciplinaTurma DisciplinaTurma { get; set; }
    }
}