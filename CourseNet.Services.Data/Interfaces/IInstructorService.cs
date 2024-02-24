using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseNet.Services.Data.Interfaces
{
    public interface IInstructorService
    {
        Task<bool> InstructorExistsByUserId(string? id);
    }
}
