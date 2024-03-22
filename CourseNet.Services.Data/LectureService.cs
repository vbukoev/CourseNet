﻿using CourseNet.Data;
using CourseNet.Services.Data.Interfaces;
using CourseNet.Web.ViewModels.Lecture;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Globalization;
using CourseNet.Data.Models.Entities;
using CourseNet.Web.ViewModels.Category;
using static CourseNet.Common.DataConstants.Lecture;
using CourseNet.Common.DataConstants;
using Course = CourseNet.Data.Models.Entities.Course;
using Lecture = CourseNet.Data.Models.Entities.Lecture;


namespace CourseNet.Services.Data
{
    public class LectureService : ILectureService
    {
        private readonly CourseNetDbContext context;
        private readonly ICourseService courseService;

        public LectureService(CourseNetDbContext context, ICourseService courseService)
        {
            this.context = context;
            this.courseService = courseService;
        }

        public async Task<IEnumerable<Lecture>> GetAllLecturesForCourseAsync(Guid courseId)
        {
            return await context.Lectures
                .Where(l => l.CourseId == courseId)
                .ToListAsync();
        }

        public async Task AddLectureToCourseAsync(LectureSelectionFormViewModel viewModel, string courseId)
        {
            var lecture = new Lecture
            {
                Title = viewModel.Title,
                Description = viewModel.Description,
                CourseId = Guid.Parse(courseId)
            };

            await context.Lectures.AddAsync(lecture);
            await context.SaveChangesAsync();
        }

    }
}
