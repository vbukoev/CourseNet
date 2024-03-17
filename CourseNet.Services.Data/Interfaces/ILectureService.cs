using CourseNet.Web.ViewModels.Category;
using CourseNet.Web.ViewModels.Lecture;

namespace CourseNet.Services.Data.Interfaces
{
    public interface ILectureService
    {
        Task<IEnumerable<LectureSelectionFormViewModel>> GetAllLecturesForCourseAsync(string courseId);

        Task<bool> LectureExists(int lectureId);

        Task<bool> LectureExistsByCourseId(string courseId);

        Task<IEnumerable<AllLecturesForCourseViewModel>> AllLecturesAsync();
    }
}
