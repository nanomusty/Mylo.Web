using Mylo.Web.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mylo.Web.ObjectModels
{
    public class ClientTransaction
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid ClientId { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        public TransactionType TransactionType { get; set; }

        [Required]
        [StringLength(100)]
        public string Category { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; }

        [StringLength(100)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(100)]
        public string ModifiedBy { get; set; }

        [ForeignKey("ClientId")]
        public virtual ClientModel Client { get; set; }
    }
}