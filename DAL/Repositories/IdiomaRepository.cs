using Domain;
using System.Collections.Generic;

namespace DAL.Repositories
{
    public class IdiomaRepository
    {
        public IList<Idioma> ObtenerIdiomasSoportados()
        {
            return new List<Idioma>
            {
                new Idioma {CodigoIso = "es-AR", Nombre = "Español (Argentina)"},
                new Idioma {CodigoIso = "en-US", Nombre = "English (United States)"},
            };
        }
    }
}