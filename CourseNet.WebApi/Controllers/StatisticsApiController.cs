using System.Net;
using CourseNet.Services.Data.Interfaces;
using CourseNet.Services.Data.Models.Statistics;
using Microsoft.AspNetCore.Mvc;

namespace CourseNet.WebApi.Controllers
{
    [Route("api/statistics")]
    [ApiController]
    public class StatisticsApiController : ControllerBase
    {
        private readonly ICourseService courseService;

        public StatisticsApiController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(StatisticsServiceModel))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<StatisticsServiceModel>> GetStatistics()
        {
            try
            {
                var statistics = await this.courseService.GetStatisticsAsync();

                return Ok(statistics);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
