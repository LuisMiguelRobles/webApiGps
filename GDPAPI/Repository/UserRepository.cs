using System;
using GDPAPI.Models;
using GDPAPI.Persistence.Context;
using GDPAPI.Repository.Interfaces;

namespace GDPAPI.Repository
{
    public class UserRepository : IUser
    {
        private readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }
        public User GetUser(string email)
        {
            throw new NotImplementedException();
        }

        public void AddUser(User user)
        {
            _context.Add(user);
        }
    }
}
