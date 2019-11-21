using GDPAPI.Models;

namespace GDPAPI.Repository.Interfaces
{
    public interface IUser
    {
        User GetUser(string email);

        void AddUser(User user);
    }
}
