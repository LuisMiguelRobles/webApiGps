using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GDPAPI.Models.EnumModels;

namespace GDPAPI.ViewModels
{
    public class UserViewModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
