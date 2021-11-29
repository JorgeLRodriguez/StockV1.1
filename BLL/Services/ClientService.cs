using BLL.Contracts;
using Domain;
using Services.BLL.Contracts;
using Services.BLL.Services;
using Services.Domain.Logger;
using Services.Factory;
using Services.Services.Security;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    class ClientService : IClientService
    {
        private readonly IUserTranslator _userTranslator;
        //#region Singleton
        //private readonly static ClientService _instance = new();
        //public static ClientService Current
        //{
        //    get
        //    {
        //        return _instance;
        //    }
        //}
        public ClientService()
        {
            _userTranslator = UserTranslator.Current;
        }
        //#endregion
        public IEnumerable<Client> Get()
        {
            IEnumerable<Client> clients;
            try
            {
                clients = DAL.Factory.Factory.Current.ClientRepository.Get();
            }
            catch (Exception ex)
            {
                ApplicationServices.Current.GetLogService.SaveLog
                    (new Log() { Event_ID = 7, Message = ex.Message, Severity = Severity.Critical, User = ServicesUser.GetInstance.UserLogged, DateTime = DateTime.Now }
                , TypeLog.File);
                throw;
            }
            return clients ?? throw new Exception(_userTranslator.Translate("Cliente") + ": " + _userTranslator.Translate("ErrorSinRegistros"));
        }
        public Client GetByCuit(string cuit)
        {
            Client C;
            try
            {
                C = DAL.Factory.Factory.Current.ClientRepository.Get(filter: x => x.Cuit.Equals(cuit)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                ApplicationServices.Current.GetLogService.SaveLog
                    (new Log() { Event_ID = 7, Message = ex.Message, Severity = Severity.Critical, User = ServicesUser.GetInstance.UserLogged, DateTime = DateTime.Now }
                , TypeLog.File);
                throw;
            }
            return C ?? throw new Exception(_userTranslator.Translate("Cliente") + ": " + _userTranslator.Translate("ErrorSinRegistros"));
        }
    }
}
