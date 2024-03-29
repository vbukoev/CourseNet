﻿using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using CourseNet.Common.DataConstants;
using static CourseNet.Common.DataConstants.Material;
namespace CourseNet.Data.Models.Entities
{
    [Comment("Material Table")]
    public class Material
    {
        [Comment("Material Identifier")]
        public int Id { get; set; }

        [Comment("Material Name")]
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = string.Empty;

        [Comment("Material Description")]
        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;

        [Comment("Lecture identifier")]
        public int LectureId { get; set; }

        [Comment("Lecture")]
        [ForeignKey(nameof(LectureId))]
        public virtual Lecture Lecture { get; set; } 
    }
}