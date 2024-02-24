using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static CourseNet.Common.DataConstants.Category;
namespace CourseNet.Data.Models.Entities
{
    [Comment("Category Table")]
    public class Category
    {
        [Key]
        [Required]
        [Comment("Category Identifier")]
        public int Id { get; set; }

        [Comment("Category Name")]
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Comment("Collection of Courses")]
        public virtual ICollection<Course> Courses { get; set; } = new HashSet<Course>();
    }
}
