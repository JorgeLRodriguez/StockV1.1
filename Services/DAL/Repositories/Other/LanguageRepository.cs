using Services.DAL.Contracts;
using Services.Domain.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Repositories.Other
{
    public class LanguageRepository: ILanguageRepository
    {
        public IList<Language> GetSupportedLanguages()
        {
            return new List<Language>
            {
                new Language {ISOCode = "es-AR", Name = "Español (Argentina)"},
                new Language {ISOCode = "en-US", Name = "English (United States)"},
            };
        }
    }
}