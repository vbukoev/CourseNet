using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CourseNet.Data.Entities
{
    [Comment("Payment Table")]
    public class Payment
    {
        [Comment("Payment Identifier")]
        [Key]
        public int Id { get; set; }
        [Comment("User Identifier")]
        [Required]
        public int UserId { get; set; }
        [Comment("User")]
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        [Comment("Amount")]
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }
        [Comment("Payment Date")]
        [Required]
        public DateTime PaymentDate { get; set; }
        [Comment("Is Successful boolean")]
        public bool IsSuccessful { get; set; }
    }
}
