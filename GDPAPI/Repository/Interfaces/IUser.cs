using System.Collections.Generic;
using GDPAPI.Models;
using GDPAPI.ViewModels;

namespace GDPAPI.Repository.Interfaces
{
    public interface IUser
    {
        User GetUser(string email);

        void AddUser(User user);

        bool IsValid(UserViewModel viewModel);

        IEnumerable<User> GetAllUser();
    }
}
