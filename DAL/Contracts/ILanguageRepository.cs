using Domain;
using System.Collections.Generic;

namespace DAL.Contracts
{
    interface ILanguageRepository
    {
        IList<Language> ObtenerIdiomasSoportados();
    }
}
