using CourseNet.Services.Data.Interfaces;
using CourseNet.Web.ViewModels.Enroll;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using static CourseNet.Common.DataConstants.GeneralApplicationConstants;

namespace CourseNet.Web.Areas.Admin.Controllers
{
    public class EnrollController : BaseAdminController
    {
        private readonly IEnrollService enrollService;
        private readonly IMemoryCache memoryCache;

        public EnrollController(IEnrollService enrollService, IMemoryCache memoryCache)
        {
            this.enrollService = enrollService;
            this.memoryCache = memoryCache;
        }

        [Route("Enroll/All")]
        public async Task<IActionResult> All()
        {
            var allEnrollments = memoryCache.Get<IEnumerable<EnrollViewModel>>(EnrollCacheKey);

            if (allEnrollments == null)
            {
                allEnrollments = await enrollService.GetAllAsync();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(EnrollCacheExpirationInMinutes));

                memoryCache.Set(UsersCacheKey, allEnrollments, cacheOptions);
            }

            return View(allEnrollments);
        }
    }
}
