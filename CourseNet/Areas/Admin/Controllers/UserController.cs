using CourseNet.Services.Data.Interfaces;
using CourseNet.Web.ViewModels.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using static CourseNet.Common.DataConstants.GeneralApplicationConstants;
namespace CourseNet.Web.Areas.Admin.Controllers
{
    public class UserController : BaseAdminController
    {
        private readonly IUserService userService;
        private readonly IMemoryCache memoryCache;
        public UserController(IUserService userService, IMemoryCache memoryCache)
        {
            this.userService = userService;
            this.memoryCache = memoryCache;
        }

        [Route("User/All")]
        public async Task<IActionResult> All()
        {
            var users = memoryCache.Get<IEnumerable<UserViewModel>>(UsersCacheKey);

            if (users == null)
            {
                users = await userService.GetAllUsersAsync();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(UsersCacheExpirationInMinutes));

                memoryCache.Set(UsersCacheKey, users, cacheOptions);
            }

            return View(users);
        }
    }
}
