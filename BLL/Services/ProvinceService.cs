using BLL.Contracts;
using Domain;
using Services.BLL.Contracts;
using Services.Factory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    internal sealed class ProvinceService : SaveApplicationLog, IProvinceService
    {
        private readonly IUserTranslator _userTranslator;
        public ProvinceService()
        {
            _userTranslator = ApplicationServices.GetInstance().GetUserTranslator;
        }
        public Province Create(Province entity)
        {
            try
            {
                entity = DAL.Factory.Factory.Current.ProvinceRepository.Create(entity);
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
                DAL.Factory.Factory.Current.ProvinceRepository.Delete(ID);
                DAL.Factory.Factory.Current.SaveChanges();
            }
            catch (Exception ex)
            {
                SaveException(ex);
            }
        }
        public List<Province> GetAll()
        {
            List<Province> list = null;
            try
            {
                list = DAL.Factory.Factory.Current.ProvinceRepository.Get().ToList();
            }
            catch (Exception ex)
            {
                SaveException(ex);
            }
            return list ?? throw new Exception(_userTranslator.Translate("Provincia") + ": " + _userTranslator.Translate("ErrorSinRegistros"));
        }
        public void Update(Province entity)
        {
            try
            {
                DAL.Factory.Factory.Current.ProvinceRepository.Update(entity);
                DAL.Factory.Factory.Current.SaveChanges();
            }
            catch (Exception ex)
            {
                SaveException(ex);
            }
        }
    }
}
