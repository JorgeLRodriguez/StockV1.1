using Domain;
using System.Collections.Generic;

namespace BLL.Contracts
{
    public interface IArticleService : IGetbyIDService<Article>
    {
        List<Article> GetByClient(Client client);
        Article GetByFS(string FSCode);
    }
}
