using AutoMapper;
using Beer2Beer.Data.Contracts;
using Beer2Beer.Models;
using Beer2Beer.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beer2Beer.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IBeer2BeerDbContext context;

        public StatisticsService(IBeer2BeerDbContext context)
        {
            this.context = context;
        }

        public async Task<int> TotalPostsCount()
        {
            return await this.context.Set<Post>()
                .Where(p=>!p.IsDeleted)
                .CountAsync();
        }

        public async Task<int> TotalUsersCount()
        {
            return await this.context.Set<User>()
                .Where(u => !u.IsDeleted)
                .CountAsync();
        }
    }
}
