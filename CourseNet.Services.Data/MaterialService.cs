using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseNet.Data;
using CourseNet.Data.Models.Entities;
using CourseNet.Services.Data.Interfaces;
using CourseNet.Web.ViewModels.Material;
using Microsoft.EntityFrameworkCore;

namespace CourseNet.Services.Data
{
    public class MaterialService : IMaterialService
    {
        private readonly CourseNetDbContext context;
        private readonly ILectureService lectureService;

        public MaterialService(CourseNetDbContext context, ILectureService lectureService)
        {
            this.context = context;
            this.lectureService = lectureService;
        }
        public async Task<IEnumerable<Material>> GetAllMaterialsForLectureAsync(int lectureId)
        {
            return await context.Materials
                .Where(m => m.LectureId == lectureId)
                .ToListAsync();
        }

        public async Task AddMaterialToLectureAsync(MaterialSelectionFormViewModel model, int lectureId)
        {
            var material = new Material
            {
                Name = model.Name,
                Description = model.Description,
                LectureId = lectureId,
            };

            await context.Materials.AddAsync(material);
            await context.SaveChangesAsync();
        }

        public async Task<MaterialSelectionFormViewModel> GetMaterialForDeleteByIdAsync(int materialId)
        {
            var material = await context.Materials
                .Where(m => m.Id == materialId)
                .FirstOrDefaultAsync();

            var materialSelectionFormViewModel = new MaterialSelectionFormViewModel
            {
                Name = material.Name,
                Description = material.Description,
                LectureId = material.LectureId,
            };

            return materialSelectionFormViewModel;
        }

        public async Task DeleteMaterialByIdAsync(int materialId)
        {
            var materialToDelete = await context.Materials
                .Where(m => m.Id == materialId)
                .FirstAsync();

            context.Materials.Remove(materialToDelete);
            await context.SaveChangesAsync();
        }

        public async Task<MaterialSelectionFormViewModel> GetMaterialForUpdateAsync(int materialId)
        {
            var material = await context.Materials
                .Where(m => m.Id == materialId)
                .FirstAsync();

            return new MaterialSelectionFormViewModel
            {
                Name = material.Name,
                Description = material.Description,
                LectureId = material.LectureId,
            };
        }

        public async Task UpdateMaterialAsync(MaterialSelectionFormViewModel model, int materialId)
        {
            var material = await context.Materials
                .Where(m => m.Id == materialId)
                .FirstAsync();

            material.Name = model.Name;
            material.Description = model.Description;
            material.LectureId = model.LectureId;
        }
    }
}
