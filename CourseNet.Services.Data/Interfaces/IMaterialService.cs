using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseNet.Data.Models.Entities;
using CourseNet.Web.ViewModels.Material;

namespace CourseNet.Services.Data.Interfaces
{
    public interface IMaterialService
    {
        Task<IEnumerable<Material>> GetAllMaterialsForLectureAsync(int lectureId);

        Task AddMaterialToLectureAsync(MaterialSelectionFormViewModel material, int lectureId);

        public Task<MaterialSelectionFormViewModel> GetMaterialForDeleteByIdAsync(int materialId);

        public Task DeleteMaterialByIdAsync(int materialId);

        public Task<MaterialSelectionFormViewModel> GetMaterialForUpdateAsync(int materialId);

        public Task UpdateMaterialAsync(MaterialSelectionFormViewModel model, int materialId);
    }
}
