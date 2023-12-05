using BLL.Contracts;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    internal sealed class DepositService : SaveApplicationLog, IDepositService
    {
        public DepositService() { }
        public Deposit Create(Deposit entity)
        {
            try
            {
                entity = DAL.Factory.Factory.Current.DepositRepository.Create(entity);
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
                DAL.Factory.Factory.Current.DepositRepository.Delete(ID);
                DAL.Factory.Factory.Current.SaveChanges();
            }
            catch (Exception ex)
            {
                SaveException(ex);
            }
        }
        public List<Deposit> GetAll()
        {
            List<Deposit> dep = null;
            try
            {
                dep = DAL.Factory.Factory.Current.DepositRepository.Get().ToList();
            }
            catch (Exception ex)
            {
                SaveException(ex);
            }
            if (dep.Equals(null) || dep.Count == 0) throw new Exception("ErrorSinRegistros");
            return dep;
        }
        public void Update(Deposit entity)
        {
            try
            {
                DAL.Factory.Factory.Current.DepositRepository.Update(entity);
                DAL.Factory.Factory.Current.SaveChanges();
            }
            catch (Exception ex)
            {
                SaveException(ex);
            }
        }
    }
}
