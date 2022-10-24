using Beer2Beer.DTO;
using Beer2Beer.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Beer2Beer.Web.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/statistics")]
    public class StatisticsController : ControllerBase
    {
        private IStatisticsService statisticsService;
        public StatisticsController(IStatisticsService statisticsService) {
            this.statisticsService = statisticsService;
        }

        [HttpGet("userCount")]
        public async Task<IActionResult> GetUsersCount()
        {
            return new OkObjectResult(await this.statisticsService.TotalUsersCount());
        }
        [HttpGet("postCount")]
        public async Task<IActionResult> GetPostsCount()
        {
            return new OkObjectResult(await this.statisticsService.TotalUsersCount());
        }


    }
}
