using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace CourseNet.Data.Models.Entities
{
    [Comment("User Table")]
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = System.Guid.NewGuid();
        }
        public ICollection<Course> AppliedCourses { get; set; } = new HashSet<Course>();
    }
}
