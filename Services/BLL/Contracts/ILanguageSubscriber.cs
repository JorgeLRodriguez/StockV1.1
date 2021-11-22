using Services.Domain.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BLL.Contracts
{
    public interface ILanguageSubscriber
    {
        void LanguageChanged(Language newLanguage);
    }
}
