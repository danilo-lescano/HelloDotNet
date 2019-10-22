using System.ComponentModel.DataAnnotations;

namespace TaCertoForms.Models{
    public class Licenca {
        [Key]
        public int IdLicenca { get; set; }
        public int IdInstituicao { get; set; }
        public int NumeroDeLinceca { get; set; }
        public string ValidadeLicenca { get; set; }
    }
}