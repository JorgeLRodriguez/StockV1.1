using BLL.Contracts;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using Services.Factory;
using Services.Domain.Logger;
using Services.Services.Security;
using Services.BLL.Services;
using Services.BLL.Contracts;

namespace BLL.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IUserTranslator _userTranslator;
        //#region Singleton
        //private readonly static ArticleService _instance = new();
        //public static ArticleService Current
        //{
        //    get
        //    {
        //        return _instance;
        //    }
        //}
        public ArticleService()
        {
            _userTranslator = UserTranslator.Current;
        }
        //#endregion
        public IEnumerable<Article> GetByClient(Client client)
        {
            IEnumerable<Article> articles;
            try
            {
                articles = DAL.Factory.Factory.Current.ArticleRepository.Get(filter: x => x.Client_ID == client.ID);

            }
            catch (Exception ex)
            {
                ApplicationServices.Current.GetLogService.SaveLog
                    (new Log() { Event_ID = 7, Message = ex.Message, Severity = Severity.Critical, User = ServicesUser.GetInstance.UserLogged, DateTime = DateTime.Now}
                , TypeLog.File);
                throw;
            }
            if (!articles.Any()) throw new Exception(_userTranslator.Translate("Articulo") + ": " + _userTranslator.Translate("ErrorSinRegistros"));
            return articles;
        }
        public Article GetByFS(string FSCode)
        {
            Article A = null;
            try
            {
                A = DAL.Factory.Factory.Current.ArticleRepository.Get(filter: x => x.FsCode.Equals(FSCode)).FirstOrDefault();

            }
            catch (Exception ex)
            {
                ApplicationServices.Current.GetLogService.SaveLog
                    (new Log() { Event_ID = 7, Message = ex.Message, Severity = Severity.Critical, User = ServicesUser.GetInstance.UserLogged, DateTime = DateTime.Now }
                    , TypeLog.File);
                throw;
            }
            return A ?? throw new Exception(_userTranslator.Translate("Articulo") + ": " + _userTranslator.Translate("ErrorSinRegistros"));
        }
        public Article GetByID(Guid ID)
        {
            Article A = null;
            try
            {
                A = DAL.Factory.Factory.Current.ArticleRepository.GetById(ID);
            }
            catch (Exception ex)
            {
                ApplicationServices.Current.GetLogService.SaveLog
                    (new Log() { Event_ID = 7, Message = ex.Message, Severity = Severity.Critical, User = ServicesUser.GetInstance.UserLogged, DateTime = DateTime.Now }
                    , TypeLog.File);
                throw;
            }
            return A ?? throw new Exception(_userTranslator.Translate("Articulo") + ": " + _userTranslator.Translate("ErrorSinRegistros"));
        }
    }
}
