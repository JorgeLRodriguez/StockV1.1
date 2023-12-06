using BLL.Contracts;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    internal sealed class PalletService : SaveApplicationLog, IPalletService
    {
        public PalletService() { }
        public Pallet Create(Pallet entity)
        {
            try
            {
                entity = DAL.Factory.Factory.Current.PalletRepository.Create(entity);
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
                DAL.Factory.Factory.Current.PalletRepository.Delete(ID);
                DAL.Factory.Factory.Current.SaveChanges();
            }
            catch (Exception ex)
            {
                SaveException(ex);
            }
        }
        public List<Pallet> GetAll()
        {
            List<Pallet> list = null;
            try
            {
                list = DAL.Factory.Factory.Current.PalletRepository.Get().ToList();
            }
            catch (Exception ex)
            {
                SaveException(ex);
            }
            if (list.Equals(null) || list.Count == 0) throw new Exception("ErrorSinRegistros");
            return list;
        }
        public List<Pallet> GetByDep(Deposit deposit)
        {
            List<Pallet> list = null;
            try
            {
                list = DAL.Factory.Factory.Current.PalletRepository.Get(filter: x => x.Deposit.ID.Equals(deposit.ID)).ToList();
            }
            catch (Exception ex)
            {
                SaveException(ex);
            }
            if (list.Equals(null) || list.Count() == 0) throw new Exception("ErrorSinRegistros");
            return list;
        }
        public void Update(Pallet entity)
        {
            try
            {
                DAL.Factory.Factory.Current.PalletRepository.Update(entity);
                DAL.Factory.Factory.Current.SaveChanges();
            }
            catch (Exception ex)
            {
                SaveException(ex);
            }
        }
    }
}
