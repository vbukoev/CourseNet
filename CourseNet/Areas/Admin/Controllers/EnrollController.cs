using CourseNet.Services.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CourseNet.Web.Areas.Admin.Controllers
{
    public class EnrollController : BaseAdminController
    {
        private readonly IEnrollService enrollService;

        public EnrollController(IEnrollService enrollService)
        {
            this.enrollService = enrollService;
        }

        [Route("Enroll/All")]
        public async Task<IActionResult> All()
        {
            var allEnrollments = await enrollService.GetAllAsync();
            return View(allEnrollments);
        }
    }
}
