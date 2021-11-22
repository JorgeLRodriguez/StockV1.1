using Services.Domain.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BLL.Contracts
{
    public interface IUserTranslator : ITranslator
    {
        Language PreferredLanguage { get; set; }
        IList<Language> SupportedLanguages { get; }
        void Subscribe(ILanguageSubscriber NewSubscriber);
        void Unsubscribe (ILanguageSubscriber Subscriber);
    }
}
