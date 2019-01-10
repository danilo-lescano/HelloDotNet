using Microsoft.EntityFrameworkCore;
using TaCertoForms.Models;

namespace tacertoforms_dotnet.TaCertoForms.Models
{
    public class FaseContexto : DbContext
    {
        public FaseContexto(DbContextOptions<FaseContexto> options) : base(options){

        }

        public DbSet<Fase> Fases { get; set; }
    }
}