using BLL.Contracts;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using Services.BLL.Contracts;
using Services.Factory;

namespace BLL.Services
{
    internal sealed class ArticleService : SaveApplicationLog, IArticleService
    {
        private readonly IUserTranslator _userTranslator;
        public ArticleService()
        {
            _userTranslator = ApplicationServices.GetInstance().GetUserTranslator;
        }
        public List<Article> GetByClient(Client client)
        {
            List<Article> articles = null;
            try
            {
                articles = DAL.Factory.Factory.Current.ArticleRepository.Get(filter: x => x.Client_ID == client.ID).ToList();

            }
            catch (Exception ex)
            {
                SaveException(ex);
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
                SaveException(ex);
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
                SaveException(ex);
            }
            return A ?? throw new Exception(_userTranslator.Translate("Articulo") + ": " + _userTranslator.Translate("ErrorSinRegistros"));
        }
    }
}
