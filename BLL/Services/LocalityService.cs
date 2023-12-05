using BLL.Contracts;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    internal sealed class LocalityService : SaveApplicationLog, ILocalityService
    {
        public LocalityService()
        {

        }
        public Locality Create(Locality entity)
        {
            try
            {
                entity = DAL.Factory.Factory.Current.LocalityRepository.Create(entity);
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
                DAL.Factory.Factory.Current.LocalityRepository.Delete(ID);
                DAL.Factory.Factory.Current.SaveChanges();
            }
            catch (Exception ex)
            {
                SaveException(ex);
            }
        }
        public List<Locality> GetAll()
        {
            List<Locality> localities = null;
            try
            {
                localities = DAL.Factory.Factory.Current.LocalityRepository.Get().ToList();

            }
            catch (Exception ex)
            {
                SaveException(ex);
            }
            if (!localities.Any()) throw new Exception("Localidad: ErrorSinRegistros");
            return localities;
        }
        public Locality GetByID(Guid ID)
        {
            Locality A = null;
            try
            {
                A = DAL.Factory.Factory.Current.LocalityRepository.GetById(ID);
            }
            catch (Exception ex)
            {
                SaveException(ex);
            }
            return A ?? throw new Exception("Localidad: ErrorSinRegistros");
        }
        public void Update(Locality entity)
        {
            try
            {
                DAL.Factory.Factory.Current.LocalityRepository.Update(entity);
                DAL.Factory.Factory.Current.SaveChanges();
            }
            catch (Exception ex)
            {
                SaveException(ex);
            }
        }
    }
}
