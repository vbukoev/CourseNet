using CourseNet.Data;
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

        public async Task<IEnumerable<LecturesForCourseViewModel>> GetAllLecturesForCourseAsync(string courseId)
        {
            var lectures = await context.Lectures
                    .Where(l => l.CourseId.ToString() == courseId)
                .Select(c => new LecturesForCourseViewModel
                {
                    Title = c.Title,
                    Description = c.Description,
                })
                .ToListAsync();

            return lectures;
        }

        public async Task<bool> LectureExists(int lectureId)
        {
            bool res = await context.Lectures.AnyAsync(c => c.Id == lectureId);

            return res;
        }

        public async Task<bool> IsValidInstructor(string instructorId)
        {
            return await context.Instructors.AnyAsync(i => i.Id.ToString() == instructorId);
        }

        public async Task<bool> LectureExistsByCourseId(string courseId)
        {
            bool res = await context.Lectures.AnyAsync(l => l.Course.Id.ToString() == courseId);

            return res;
        }

        public async Task<IEnumerable<LectureCreateViewModel>> AllLecturesAsync()
        {
            IEnumerable<LectureCreateViewModel> lectures = await context.Lectures
                .AsNoTracking()
                .Select(c => new LectureCreateViewModel
                {
                    Title = c.Title,
                    Description = c.Description,
                })
                .ToArrayAsync();

            return lectures;
        }

        public async Task AddLectureToCourseAsync(LectureSelectionFormViewModel model)
        {
            var lecture = new Lecture
            {
                Title = model.Title,
                Description = model.Description,
                //Date = model.Date,
            };

            context.Lectures.Add(lecture);
            await context.SaveChangesAsync();
        }

    }
}
