using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GDPAPI.Utilities
{
    public interface IUtilities
    {
        string EncryptPassword(string password);
        IToken Token { get; }
    }
}
