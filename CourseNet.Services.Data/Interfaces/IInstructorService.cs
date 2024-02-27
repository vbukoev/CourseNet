using CourseNet.Web.ViewModels.Instructor;

namespace CourseNet.Services.Data.Interfaces
{
    public interface IInstructorService
    {
        Task<bool> InstructorExistsByUserId(string? id);
        Task<bool> InstructorExistsByPhoneNumber(string phoneNumber);
        Task<bool> HasAppliedCoursesByUserIdAsync(string? id);
        Task Create (string userId, BecomeInstructorFormModel model);
        Task<string> GetInstructorIdByUserId(string? userId);
    }
}
