using System.ComponentModel.DataAnnotations;

namespace tacertoforms.Models{
    public class TurmaDisciplinaProfessor{
        [Key]
        public int IdTurmaDisciplinaProfessor { get; set; }
        public int IdProfessor { get; set; }
        public int IdDisciplinaTurma { get; set; }        
    }
}