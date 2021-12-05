using Services.BLL.Contracts;
using Services.DAL.Contracts;
using Services.DAL.Repositories.Other;
using Services.Domain.Language;
using System;
using System.Collections.Generic;
using System.IO;

namespace Services.BLL.Services
{
    public class UserTranslator : IUserTranslator
    {
        private Language _preferredLanguage;
        private string filePath = String.Empty;
        private readonly ILanguageRepository _languageRepository;
        private readonly IList<ILanguageSubscriber> _subscribers = new List<ILanguageSubscriber>();
        //#region Singleton
        //private readonly static UserTranslator _instance = new();
        //public static UserTranslator Current
        //{
        //    get
        //    {
        //        return _instance;
        //    }
        //}
        //private UserTranslator() : this (new LanguageRepository()){}
        //#endregion
        public UserTranslator()
        {
            _languageRepository = new LanguageRepository();
            filePath = @"Domain\Language\language.";
        }
        public Language PreferredLanguage
        {
            get { return _preferredLanguage; }
            set
            {
                _preferredLanguage = value;
                this.NotifyLanguageChanged(_preferredLanguage);
            }
        }
        public IList<Language> SupportedLanguages
        {
            get { return _languageRepository.GetSupportedLanguages(); }
        }
        public void Subscribe(ILanguageSubscriber newLanguageSubscriber)
        {
            _subscribers.Add(newLanguageSubscriber);
            newLanguageSubscriber.LanguageChanged(this.PreferredLanguage);
        }
        public void Unsubscribe(ILanguageSubscriber subscriber)
        {
            _subscribers.Remove(subscriber);
        }
        public string Translate(string key)
        {
            string translatedWord = key;

            string cultureCode = PreferredLanguage.ISOCode;

            using (StreamReader streamReader = new(filePath + cultureCode))
            {
                while (!streamReader.EndOfStream)
                {
                    string linea = streamReader.ReadLine();
                    string[] keyValuePair = linea.Split(':');

                    if (keyValuePair[0].ToLower() == key.ToLower())
                    {
                        translatedWord = keyValuePair[1];
                        break;
                    }
                    if (key.ToLower().Contains(keyValuePair[0].ToLower()) && key.Split(" ").Length > 1)
                    {
                        translatedWord = key.Replace(keyValuePair[0], keyValuePair[1]);
                        break;
                    }
                }
            }
            return translatedWord;
        }
        private void NotifyLanguageChanged(Language newLanguage)
        {
            lock (_subscribers)
            {
                foreach (var subscriber in _subscribers)
                    subscriber.LanguageChanged(newLanguage);
            }
        }
    }
}
