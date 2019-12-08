using GDPAPI.Models.EnumModels;

namespace GDPAPI.Models
{
    public class User
    {
        public int Id { get; set; }

        public string  Name { get; set; }
        
        public string LastName { get; set; }
        
        public string Password { get; set; }

        public UserType UserType { get; set; }

        public Contact Contact { get; set; }
    }
}
