using CourseNet.Web.ViewModels.Enroll;

namespace CourseNet.Services.Data.Interfaces
{
    public interface IEnrollService
    {
        Task<IEnumerable<EnrollViewModel>> GetAllAsync();
    }
}
