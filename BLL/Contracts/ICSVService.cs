using Domain;
using System.Collections.Generic;

namespace BLL.Contracts
{
    public interface ICSVService
    {
        void Create(List<CSV> CSV);
    }
}
