using BLL.Contracts;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    internal sealed class ArticleService : SaveApplicationLog, IArticleService
    {
        public ArticleService()
        {
        }
        public Article Create(Article entity)
        {
            try
            {
                entity = DAL.Factory.Factory.Current.ArticleRepository.Create(entity);
                DAL.Factory.Factory.Current.SaveChanges();
            }
            catch (Exception ex)
            {
                SaveException(ex);
            }
            return entity;
        }
        public void Delete(Guid ID)
        {
            try
            {
                DAL.Factory.Factory.Current.ArticleRepository.Delete(ID);
                DAL.Factory.Factory.Current.SaveChanges();
            }
            catch (Exception ex)
            {
                SaveException(ex);
            }
        }
        public List<Article> GetAll()
        {
            List<Article> articles = null;
            try
            {
                articles = DAL.Factory.Factory.Current.ArticleRepository.Get().ToList();

            }
            catch (Exception ex)
            {
                SaveException(ex);
            }
            if (!articles.Any()) throw new Exception("Articulo: ErrorSinRegistros");
            return articles;
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
            if (!articles.Any()) throw new Exception("Articulo: ErrorSinRegistros");
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
            return A ?? throw new Exception("Articulo: ErrorSinRegistros");
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
            return A ?? throw new Exception("Articulo: ErrorSinRegistros");
        }
        public void Update(Article entity)
        {
            try
            {
                DAL.Factory.Factory.Current.ArticleRepository.Update(entity);
                DAL.Factory.Factory.Current.SaveChanges();
            }
            catch (Exception ex)
            {
                SaveException(ex);
            }
        }
    }
}
