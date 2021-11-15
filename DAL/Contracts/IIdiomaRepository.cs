using Domain;
using System.Collections.Generic;

namespace DAL.Contracts
{
    interface IIdiomaRepository
    {
        IList<Idioma> ObtenerIdiomasSoportados();
    }
}
