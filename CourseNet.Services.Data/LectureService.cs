using CourseNet.Data;
using CourseNet.Services.Data.Interfaces;
using CourseNet.Web.ViewModels.Lecture;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Globalization;
using CourseNet.Data.Models.Entities;
using CourseNet.Web.ViewModels.Category;
using static CourseNet.Common.DataConstants.Lecture;


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

        public async Task<IEnumerable<LectureSelectionFormViewModel>> GetAllLecturesForCourseAsync(string courseId)
        {
            var lectures = await context.Lectures
                    .Where(l => l.CourseId.ToString() == courseId)
                .Select(c => new LectureSelectionFormViewModel
                {
                    Title = c.Title,
                    Description = c.Description,
                    Date = c.Date.ToString(),
                })
                .ToListAsync();

            return lectures;
        }

        public async Task<bool> LectureExists(int lectureId)
        {
            bool res = await context.Lectures.AnyAsync(c => c.Id == lectureId);

            return res;
        }

        public async Task<bool> LectureExistsByCourseId(string courseId)
        {
            bool res = await context.Lectures.AnyAsync(c => c.CourseId.ToString() == courseId);

            return res;
        }

        public async Task<IEnumerable<AllLecturesForCourseViewModel>> AllLecturesAsync()
        {
            IEnumerable<AllLecturesForCourseViewModel> lectures = await context.Lectures
                .AsNoTracking() 
                .Select(c => new AllLecturesForCourseViewModel
                {
                    Title = c.Title,
                    Description = c.Description,
                    Date = c.Date.ToString(CultureInfo.InvariantCulture),
                })
                .ToArrayAsync();

            return lectures;
        }

        public async Task CreateLectureAsync(LectureSelectionFormViewModel model, string courseId)
        {
            var lecture = new Lecture
            {
                Title = model.Title,
                Description = model.Description,
                Date = DateTime.ParseExact(model.Date, TimeAndDateFormat, CultureInfo.InvariantCulture),
                CourseId = Guid.Parse(courseId)
            };

            await context.Lectures.AddAsync(lecture);
            await context.SaveChangesAsync();
        }
    }
}
