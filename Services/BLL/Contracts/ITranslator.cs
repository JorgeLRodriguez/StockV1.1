using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BLL.Contracts
{
    public interface ITranslator
    {
        string Translate(string constanteDeTexto);
       
    }
}