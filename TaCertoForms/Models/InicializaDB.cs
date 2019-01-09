using System.Linq;
using TaCertoForms.Models;

namespace tacertoforms_dotnet.TaCertoForms.Models
{
    public class InicializaDB
    {
        public static void Initialize(FaseContexto context){
            context.Database.EnsureCreated();

            // Procura por fases
            if(context.Fases.Any()){
                return; // O DB foi alimentado
            }

            var fases = new Fase[]{
                new Fase{Id = 3, UsuarioId = 123123, Chave = "abc324", IdTipoFase = 1},
                new Fase{Id = 4, UsuarioId = 123123, Chave = "abc325", IdTipoFase = 1},
            };
            foreach(Fase f in fases){
                context.Fases.Add(f);
            }
            context.SaveChanges(); // Persistencia criando a tabela e o banco de dados
        }
    }
}