﻿using CourseNet.Services.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CourseNet.Web.Areas.Admin.Controllers
{
    public class UserController : BaseAdminController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [Route("User/All")]
        public async Task<IActionResult> All()
        {
            var viewModel = await userService.GetAllUsersAsync();

            return View(viewModel);
        }
    }
}
