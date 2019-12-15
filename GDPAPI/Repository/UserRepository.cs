using System;
using System.Collections.Generic;
using System.Linq;
using GDPAPI.Models;
using GDPAPI.Persistence.Context;
using GDPAPI.Repository.Interfaces;
using GDPAPI.ViewModels;

namespace GDPAPI.Repository
{
    public class UserRepository : IUser
    {
        private readonly ApiContext _apiContext;

        public UserRepository(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }
        public User GetUser(string email)
        {
            throw new NotImplementedException();
        }
        public void AddUser(User user)
        {
            _apiContext.Add(user);
        }

        public bool IsValid(UserViewModel viewModel)
        {
            var user = _apiContext.Users.FirstOrDefault(user => user.Email == viewModel.Email);
            return user == null;
        }

        public IEnumerable<User> GetAllUser()
        {
            return _apiContext.Users;
        }
    }
}
