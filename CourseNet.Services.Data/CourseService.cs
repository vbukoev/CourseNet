using System.Globalization;
using System.Runtime.Serialization;
using CourseNet.Common.DataConstants;
using CourseNet.Data;
using CourseNet.Data.Models.Entities;
using CourseNet.Data.Models.Entities.Enums;
using CourseNet.Services.Data.Interfaces;
using CourseNet.Services.Data.Models.Course;
using CourseNet.Services.Data.Models.Statistics;
using CourseNet.Web.ViewModels.Course;
using CourseNet.Web.ViewModels.Course.Enums;
using CourseNet.Web.ViewModels.Home;
using CourseNet.Web.ViewModels.Instructor;
using Microsoft.EntityFrameworkCore;
using Course = CourseNet.Data.Models.Entities.Course;
using static CourseNet.Common.DataConstants.Course;
namespace CourseNet.Services.Data
{
    public class CourseService : ICourseService
    {
        private readonly CourseNetDbContext context;

        public CourseService(CourseNetDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<IndexViewModel>> GetAllCoursesAsync()
        {
            IEnumerable<IndexViewModel> courses = await this.context.Courses
                .Select(c => new IndexViewModel
                {
                    Id = c.Id.ToString(),
                    Title = c.Title,
                    ImagePath = c.ImagePath,
                })
                .ToListAsync();

            return courses;
        }

        public async Task<string> CreateCourseAndReturnIdAsync(CourseFormViewModel model, string instructorId)
        {
            var course = new Course
            {
                Title = model.Title,
                Description = model.Description,
                ImagePath = model.ImagePath,
                CategoryId = model.CategoryId,
                Price = model.Price,
                InstructorId = Guid.Parse(instructorId),
                Status = CourseStatus.Active,
                Difficulty = model.Difficulty,
                EndDate = DateTime.ParseExact(model.EndDate, DateFormat, CultureInfo.InvariantCulture),
            };

            await context.Courses.AddAsync(course);
            await context.SaveChangesAsync();

            return course.Id.ToString();
        }

        public async Task<AllCoursesFilteredAndPagedServiceModel> AllAsync(AllCoursesQueryModel queryModel)
        {
            IQueryable<Course> courseQuery = context
                .Courses
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryModel.Category))
            {
                courseQuery = courseQuery
                    .Where(c => c.Category.Name == queryModel.Category);
            }

            if (!string.IsNullOrWhiteSpace(queryModel.SearchTerm))
            {
                string wildCard = $"%{queryModel.SearchTerm.ToLower()}%";

                courseQuery = courseQuery
                    .Where(c =>
                        EF.Functions.Like(c.Title, wildCard) || EF.Functions.Like(c.Description, wildCard));
            }

            courseQuery = queryModel.CourseSorting switch
            {
                CourseSorting.LeastExpensive => courseQuery.OrderBy(c => c.Price),
                CourseSorting.MostExpensive => courseQuery.OrderByDescending(c => c.Price),
                CourseSorting.Newest => courseQuery.OrderByDescending(c => c.CreatedOn),
                CourseSorting.Oldest => courseQuery.OrderBy(c => c.CreatedOn),
                _ => courseQuery.OrderBy(c => c.InstructorId != null)
                    .ThenByDescending(c => c.CreatedOn)
            };

            IEnumerable<CourseAllViewModel> courses = await courseQuery
                .Skip((queryModel.CurrentPage - 1) * queryModel.CoursesPerPage)
                .Take(queryModel.CoursesPerPage)
                .Select(c => new CourseAllViewModel
                {
                    Id = c.Id.ToString(),
                    Title = c.Title,
                    Description = c.Description,
                    ImagePath = c.ImagePath,
                    Price = c.Price,
                    Difficulty = c.Difficulty.ToString(),
                    Status = c.Status.ToString(),
                    EndDate = c.EndDate.ToString(),
                    IsEnrolled = c.StudentId.HasValue,
                })
                .ToListAsync();
            int totalCourses = courseQuery.Count();

            return new AllCoursesFilteredAndPagedServiceModel
            {
                Courses = courses,
                TotalCourses = totalCourses,
            };
        }

        public async Task<IEnumerable<CourseAllViewModel>> AllByInstructorIdAsync(string instructorId)
        {
            IEnumerable<CourseAllViewModel> allInstructorCourses = await this.context.Courses
                .Where(c => c.InstructorId.ToString() == instructorId)
                .Select(c => new CourseAllViewModel
                {
                    Id = c.Id.ToString(),
                    Title = c.Title,
                    Description = c.Description,
                    ImagePath = c.ImagePath,
                    Price = c.Price,
                    Difficulty = c.Difficulty.ToString(),
                    Status = c.Status.ToString(),
                    EndDate = c.EndDate.ToString(CultureInfo.InvariantCulture),
                    IsEnrolled = c.StudentId.HasValue,
                })
                .ToListAsync();

            return allInstructorCourses;
        }

        public async Task<IEnumerable<CourseAllViewModel>> AllByUserIdAsync(string userId)
        {
            IEnumerable<CourseAllViewModel> allUserCourses = await this.context.Courses
                .Where(c => c.StudentId.HasValue && c.StudentId.ToString() == userId)
                .Select(c => new CourseAllViewModel
                {
                    Id = c.Id.ToString(),
                    Title = c.Title,
                    Description = c.Description,
                    ImagePath = c.ImagePath,
                    Price = c.Price,
                    Difficulty = c.Difficulty.ToString(),
                    Status = c.Status.ToString(),
                    EndDate = c.EndDate.ToString(),
                    IsEnrolled = c.StudentId.HasValue,
                })
                .ToListAsync();

            return allUserCourses;
        }

        public async Task<bool> ExistsByIdAsync(string houseId)
        {
            bool result = await context
                .Courses
                .AnyAsync(h => h.Id.ToString() == houseId);

            return result;
        }

        public async Task<CourseDetailsViewModel?> DetailsAsync(string courseId)
        {
            Course? course = await context.Courses
                .Include(c => c.Instructor)
                .ThenInclude(c => c.User)
                .Include(c => c.Category)
                .FirstOrDefaultAsync(c => c.Id.ToString() == courseId);

            if (course == null)
            {
                return null;
            }

            return new CourseDetailsViewModel
            {
                Id = course.Id.ToString(),
                Title = course.Title,
                Description = course.Description,
                ImagePath = course.ImagePath,
                Price = course.Price,
                Difficulty = course.Difficulty.ToString(),
                Status = course.Status.ToString(),
                EndDate = course.EndDate.ToString(CultureInfo.InvariantCulture),
                Instructor = new InstructorInfoOfCourseViewModel()
                {
                    Email = course.Instructor.Email,
                    PhoneNumber = course.Instructor.PhoneNumber,
                },
                Category = course.Category.Name,
            };
        }

        public async Task<CourseFormViewModel> GetCourseForEditByIdAsync(string courseId)
        {
            Course course = await context.Courses
                .Include(c => c.Category)
                .FirstAsync(c => c.Id.ToString() == courseId);

            return new CourseFormViewModel
            {
                Title = course.Title,
                Description = course.Description,
                ImagePath = course.ImagePath,
                EndDate = course.EndDate.ToString(),
                Difficulty = course.Difficulty,
                Price = course.Price,
                CategoryId = course.CategoryId,
            };
        }

        public async Task<bool> IsInstructorOfCourseAsync(string courseId, string instructorId)
        {
            var course = await context.Courses
                 .FirstOrDefaultAsync(c => c.Id.ToString() == courseId);

            return course.InstructorId.ToString() == instructorId;
        }

        public async Task EditCourseByIdAsync(CourseFormViewModel model, string courseId)
        {
            var course = await context.Courses
                .FirstAsync(c => c.Id.ToString() == courseId);

            course.Title = model.Title;
            course.Description = model.Description;
            course.ImagePath = model.ImagePath;
            course.EndDate = DateTime.Parse(model.EndDate);
            course.Price = model.Price;
            course.Difficulty = model.Difficulty;
            course.CategoryId = model.CategoryId;

            await context.SaveChangesAsync();
        }

        public async Task<CourseDeleteViewModel> GetCourseForDeleteByIdAsync(string courseId)
        {
            Course course = await context
                .Courses
                .FirstAsync(c => c.Id.ToString() == courseId);

            return new CourseDeleteViewModel
            {
                Title = course.Title,
                Description = course.Description,
                ImagePath = course.ImagePath,
            };
        }

        public async Task DeleteCourseByIdAsync(string courseId)
        {
            var courses = await context.Courses
                .Where(c => c.Id.ToString() == courseId)
                .ToListAsync();

            var course = await context
                .Courses
                .FirstAsync(c=>c.Id.ToString() == courseId);

            if (courses.Any())
            {
                foreach (var c in courses)
                {
                    context.Courses.Remove(c);
                }
                await context.SaveChangesAsync();
            }
        }

        public async Task<bool> IsEnrolledByIdAsync(string courseId)
        {
            return await context.Courses
                .AnyAsync(c => c.Id.ToString() == courseId && c.StudentId.HasValue);
        }

        public async Task EnrollCourseAsync(string courseId, string userId)
        {
            var course = await context
                .Courses
                .FirstAsync(c => c.Id.ToString() == courseId);

            course.StudentId = Guid.Parse(userId);

            await context.SaveChangesAsync();
        }

        public async Task<bool> IsEnrolledByIdAsync(string courseId, string userId)
        {
            var course = await context.Courses
                .FirstAsync(c => c.Id.ToString() == courseId);

            return course.StudentId.HasValue &&
                   course.StudentId.ToString() == userId;
        }

        public async Task LeaveCourseAsync(string courseId)
        {
            var course = await context.Courses
                .FirstAsync(c => c.Id.ToString() == courseId);

            course.StudentId = null;

            await context.SaveChangesAsync();
        }

        public async Task<StatisticsServiceModel> GetStatisticsAsync()
        {
            return new StatisticsServiceModel()
            {
                TotalCourses = await context.Courses.CountAsync(),
                TotalEnrollments = await context.Courses.CountAsync(c => c.StudentId.HasValue),
            };
        }

        public async Task DeleteCoursesByCategoryIdAsync(int categoryId)
        {
            var coursesToDelete = context.Courses.Where(c => c.CategoryId == categoryId);

            context.Courses.RemoveRange(coursesToDelete); // We use RemoveRange to delete all courses with the given categoryId

            await context.SaveChangesAsync();
        }
    }
}
