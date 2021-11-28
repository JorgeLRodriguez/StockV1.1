using Services.Domain.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Logger
{
    public interface ILogger
    {
        List<Log> GetAll();
        void Store(Log log);
    }
}
