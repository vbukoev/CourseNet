using CourseNet.Data.Models.Entities;
using CourseNet.Web.ViewModels.Category;
using CourseNet.Web.ViewModels.Lecture;

namespace CourseNet.Services.Data.Interfaces
{
    public interface ILectureService
    {
        Task<IEnumerable<Lecture>> GetAllLecturesForCourseAsync(Guid courseId);

        Task<bool> LectureExists(int lectureId);

        Task<bool> IsValidInstructor(string instructorId);

        Task<bool> LectureExistsByCourseId(string courseId);
        

        Task AddLectureToCourseAsync(LectureSelectionFormViewModel model, Guid courseId); 
    }
}
