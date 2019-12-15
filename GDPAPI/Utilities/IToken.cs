using GDPAPI.Models;
using GDPAPI.ViewModels;

namespace GDPAPI.Utilities
{
    public interface IToken
    {
        string GetToken(User user, byte[] key);
    }
}