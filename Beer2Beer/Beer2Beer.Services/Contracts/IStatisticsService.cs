using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beer2Beer.Services.Contracts
{
    public interface IStatisticsService
    {
        Task<int> TotalUsersCount();
        Task<int> TotalPostsCount();
    }
}
