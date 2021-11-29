using BLL.Contracts;
using Domain;
using System;
using System.Collections.Generic;

namespace BLL.Services
{
    class AddresseeService : IAddresseeService
    {
        #region Singleton
        private readonly static AddresseeService _instance = new();
        public static AddresseeService Current
        {
            get
            {
                return _instance;
            }
        }
        private AddresseeService()
        {

        }
        #endregion
        public Addressee Create(Addressee addressee)
        {
            throw new NotImplementedException();
        }

        public void Update(Addressee addressee)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Addressee> Get()
        {
            throw new NotImplementedException();
        }
    }
}
