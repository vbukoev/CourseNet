using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseNet.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseNet.Data.Configurations
{
    public class MaterialEntityConfiguration : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            
            builder.HasOne(m => m.Lecture);

            //builder.HasData(GenerateMaterials());
        }

        //public Material[] GenerateMaterials()
        //{
        //    return new Material[]
        //    {
        //        new Material()
        //        {
        //            Name = ,
        //            Description = ,
        //            CourseId = ,
        //            InstructorId = ,
        //            LectureId = ,
        //        }
        //    };
        //}
    }
}
