using Beer2Beer.Data.Contracts;
using System.Threading.Tasks;
using AutoMapper;
using Beer2Beer.Models;

namespace Beer2Beer.Services
{
    public class UserService
    {
        private readonly IBeer2BeerDbContext context;
        private readonly IMapper mapper;

        public UserService(IBeer2BeerDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
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

            this.context.DbSet<User>().Add(user);

            await this.context.SaveChangesAsync();
        }
    }
}
