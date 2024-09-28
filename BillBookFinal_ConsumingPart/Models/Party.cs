using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BillBookFinal_ConsumingPart.Models
{
    public class Party
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Auto-incrementing ID

        [Required]
        [StringLength(100)]
        public string PartyName { get; set; }

        [Required]
        [StringLength(255)]
        [EmailAddress] // Optional: Validates that the email is in the correct format
        public string Email { get; set; }

        [Required]
        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal OpeningBalance { get; set; } = 0.00m;

        [StringLength(15)]
        public string GSTINumber { get; set; }

        [StringLength(10)]
        public string PANCardNumber { get; set; }

        [StringLength(255)]
        public string PartyTypeId { get; set; }

        [StringLength(50)]
        public string PartyCategory { get; set; }

        [StringLength(255)]
        public string BillingAddress { get; set; }

        [StringLength(255)]
        public string ShippingAddress { get; set; }

        public int? CreditPeriod { get; set; } // Assuming this can be nullable

        [Column(TypeName = "decimal(18,2)")]
        public decimal CreditLimit { get; set; } = 0.00m;
    }
}
