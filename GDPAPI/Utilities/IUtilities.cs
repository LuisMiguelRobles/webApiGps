
namespace GDPAPI.Utilities
{
    public interface IUtilities
    {
        string EncryptPassword(string password);
        IToken Token { get; }
    }
}
