using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Beer2Beer.Data.Contracts
{
    public interface IBeer2BeerDbContext
    {
        DbSet<T> DbSet<T>() where T : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
