﻿using CourseNet.Services.Data.Interfaces;
using CourseNet.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CourseNet.Web.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IInstructorService instructorService;

        public InstructorController(IInstructorService instructorService)
        {
            this.instructorService = instructorService;
        }
        [HttpGet]
        public async Task<IActionResult> Become()
        {
            string? userId = this.User.GetId();
            bool isInstructor = await this.instructorService.InstructorExistsById(userId);

            if (isInstructor)
            {
                return BadRequest();
            }
            return View();
        }
    }
}