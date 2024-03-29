﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CourseNet.Common.DataConstants.Lecture;
using Microsoft.EntityFrameworkCore;

namespace CourseNet.Data.Models.Entities
{
    [Comment("Lecture Table")]
    public class Lecture
    {

        [Comment("Lecture Identifier")]
        public int Id { get; set; }

        [Comment("Lecture Title")]
        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = string.Empty;

        [Comment("Lecture Description")]
        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;

        [Comment("Lecture Date")]
        [Required]
        public DateTime Date { get; set; }

        [Comment("Course Identifier")]
        public Guid CourseId { get; set; }  

        [Comment("Course")]
        [ForeignKey(nameof(CourseId))]
        public virtual Course Course { get; set; }

        [Comment("Collection of Materials")]
        public virtual ICollection<Material> Materials { get; set; } = new HashSet<Material>();
    }
}