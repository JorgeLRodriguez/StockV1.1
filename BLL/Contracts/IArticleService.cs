using Domain;
using System;
using System.Collections.Generic;

namespace BLL.Contracts
{
    public interface IArticleService
    {
        IEnumerable<Article> GetByClient(Client client);
        Article GetByID(Guid ID);
        Article GetByFS(string FSCode);
    }
}
