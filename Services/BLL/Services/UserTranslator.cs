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
        #region Singleton
        private readonly static UserTranslator _instance = new();
        public static UserTranslator Current
        {
            get
            {
                return _instance;
            }
        }
        private UserTranslator() : this (new LanguageRepository()){}
        #endregion
        private UserTranslator(ILanguageRepository language)
        {
            _languageRepository = language;
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
        public void Subscribe(ILanguageSubscriber nuevoSubscriptor)
        {
            _subscribers.Add(nuevoSubscriptor);
            //Notifico al nuevo subscriptor la configuración actual
            nuevoSubscriptor.LanguageChanged(this.PreferredLanguage);
        }
        public void Unsubscribe(ILanguageSubscriber subscriber)
        {
            _subscribers.Remove(subscriber);
        }
        public string Translate(string key)
        {
            string translatedWord = key;

            string culturaCodigo = this.PreferredLanguage.ISOCode;

            using (StreamReader streamReader = new StreamReader(filePath + culturaCodigo))
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
                }
            }
            return translatedWord;
        }
        private void NotifyLanguageChanged(Language newLanguage)
        {
            //Notifico a la colección de subscriptores
            lock (_subscribers)
            {
                foreach (var subscriptor in _subscribers)
                    subscriptor.LanguageChanged(newLanguage);
            }
        }
        //private string TraducirMensaje(string mensaje, ResourceManager resourceManager)
        //{
        //    var propertyInfos = typeof(ConstantesTexto).GetFields();

        //    foreach (var item in propertyInfos)
        //    {
        //        if (mensaje.ToLower().Contains(item.Name.ToLower()))
        //        {
        //            mensaje = mensaje.Replace(item.Name, resourceManager.GetString(
        //                item.Name, CultureInfo.GetCultureInfo(this.PreferredLanguage.ISOCode)));
        //        }
        //    }
        //    return mensaje;
        //}
    }
}
