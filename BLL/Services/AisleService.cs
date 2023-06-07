using BLL.Contracts;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    internal sealed class AisleService : SaveApplicationLog, IAisleService
    {
        public Aisle Create(Aisle entity)
        {
            try
            {
                entity = DAL.Factory.Factory.Current.AisleRepository.Create(entity);
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
                DAL.Factory.Factory.Current.AisleRepository.Delete(ID);
                DAL.Factory.Factory.Current.SaveChanges();
            }
            catch (Exception ex)
            {
                SaveException(ex);
            }
        }
        public List<Aisle> GetAll()
        {
            List<Aisle> aisles = null;
            try
            {
                aisles = DAL.Factory.Factory.Current.AisleRepository.Get().ToList();

            }
            catch (Exception ex)
            {
                SaveException(ex);
            }
            if (!aisles.Any()) throw new Exception("Pasillo : ErrorSinRegistros");
            return aisles;
        }
        public void Update(Aisle entity)
        {
            try
            {
                DAL.Factory.Factory.Current.AisleRepository.Update(entity);
                DAL.Factory.Factory.Current.SaveChanges();
            }
            catch (Exception ex)
            {
                SaveException(ex);
            }
        }
    }
}
