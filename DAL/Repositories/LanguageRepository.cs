using Domain;
using System.Collections.Generic;

namespace DAL.Repositories
{
    public class LanguageRepository
    {
        public IList<Language> ObtenerIdiomasSoportados()
        {
            return new List<Language>
            {
                new Language {CodigoIso = "es-AR", Nombre = "Español (Argentina)"},
                new Language {CodigoIso = "en-US", Nombre = "English (United States)"},
            };
        }
    }
}