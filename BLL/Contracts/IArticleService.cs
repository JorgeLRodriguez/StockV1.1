using Domain;
using System.Collections.Generic;

namespace BLL.Contracts
{
    public interface IArticleService : IGetbyIDService<Article>, IGetAllService<Article>, ICreateService<Article>, IUpdateService<Article>, IDeleteService<Article>
    {
        List<Article> GetByClient(Client client);
        Article GetByFS(string FSCode);
    }
}
