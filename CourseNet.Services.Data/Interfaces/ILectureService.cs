using CourseNet.Data.Models.Entities;
using CourseNet.Web.ViewModels.Category;
using CourseNet.Web.ViewModels.Lecture;

namespace CourseNet.Services.Data.Interfaces
{
    public interface ILectureService
    {
        Task<IEnumerable<LecturesForCourseViewModel>> GetAllLecturesForCourseAsync(string courseId);

        Task<bool> LectureExists(int lectureId);

        Task<bool> IsValidInstructor(string instructorId);

        Task<bool> LectureExistsByCourseId(string courseId);

        Task<IEnumerable<LectureSelectionFormViewModel>> AllLecturesAsync();

        Task AddLectureToCourseAsync(LectureSelectionFormViewModel model, string courseId); 
    }
}
