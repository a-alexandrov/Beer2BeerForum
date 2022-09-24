using System;
using System.Threading.Tasks;

namespace Beer2Beer.Services
{
    public class UserService
    {
        public UserService(context)
        {
                
        }

        public async Task CreateUser(string userName, string firstName, string lastName, string password)
        {
            var user = new User
            {
                Username = userName,
                FirstName = firstName,
                LastName = lastName,
                PasswordHash = password
            };

            context.Users.Add(user);


            await context.SaveChangesAsync();
        }
    }
}
