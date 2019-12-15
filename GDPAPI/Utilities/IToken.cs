using GDPAPI.Models;

namespace GDPAPI.Utilities
{
    public interface IToken
    {
        string GetToken(User user);
    }
}