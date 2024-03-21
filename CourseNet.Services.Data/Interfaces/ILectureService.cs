using CourseNet.Data.Models.Entities;
using CourseNet.Web.ViewModels.Category;
using CourseNet.Web.ViewModels.Lecture;

namespace CourseNet.Services.Data.Interfaces
{
    public interface ILectureService
    {
        Task<IEnumerable<LectureSelectionFormViewModel>> GetAllLecturesForCourseAsync(string courseId);

        Task<bool> LectureExists(int lectureId);

        Task<bool> IsValidInstructor(string instructorId);

        Task<bool> LectureExistsByCourseId(string courseId);

        Task<IEnumerable<AllLecturesForCourseViewModel>> AllLecturesAsync();

        Task<string> CreateLectureAsync(LectureSelectionFormViewModel model);
    }
}
