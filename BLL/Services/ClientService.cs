using BLL.Contracts;
using Domain;
using Services.BLL.Contracts;
using Services.Factory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    internal sealed class ClientService : SaveApplicationLog, IClientService
    {
        private readonly IUserTranslator _userTranslator;
        public ClientService()
        {
            _userTranslator = ApplicationServices.GetInstance().GetUserTranslator;
        }
        public List<Client> GetAll()
        {
            List<Client> clients = null;
            try
            {
                clients = DAL.Factory.Factory.Current.ClientRepository.Get().ToList();
            }
            catch (Exception ex)
            {
                SaveException(ex);
            }
            return clients ?? throw new Exception(_userTranslator.Translate("Cliente") + ": " + _userTranslator.Translate("ErrorSinRegistros"));
        }
        public Client GetByCuit(string cuit)
        {
            Client C = null;
            try
            {
                C = DAL.Factory.Factory.Current.ClientRepository.Get(filter: x => x.Cuit.Equals(cuit)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                SaveException(ex);
            }
            return C ?? throw new Exception(_userTranslator.Translate("Cliente") + ": " + _userTranslator.Translate("ErrorSinRegistros"));
        }
    }
}
