using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BLL.Contracts
{
    interface ICryptography
    {
        string Encrypt(string planeText);
        string Decrypt(string cipherText);
    }
}
