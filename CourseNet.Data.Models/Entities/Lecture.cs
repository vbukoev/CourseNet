using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CourseNet.Data.Models.Entities
{
    [Comment("Lecture Table")]
    public class Lecture
    {
        public Lecture()
        {
            this.Id = System.Guid.NewGuid();
        }
        [Comment("Lecture Identifier")]
        public Guid Id { get; set; }
        [Comment("Lecture Title")]
        public string Title { get; set; }
        [Comment("Lecture Description")]
        public string Description { get; set; }
        [Comment("Lecture Date")]
        public DateTime Date { get; set; }
        [Comment("Course Identifier")]
        public Guid CourseId { get; set; }
        [Comment("Course")]
        public Course Course { get; set; }
        [Comment("Instructor Identifier")]
        public Guid InstructorId { get; set; }
        [Comment("Instructor")]
        public Instructor Instructor { get; set; }
    }
}
