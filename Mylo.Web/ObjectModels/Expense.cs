using Mylo.Web.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace Mylo.Web.ObjectModels
{
    public class Expense : BaseEntity
    {
        [Required]
        public Guid OrganisationId { get; set; }

        [Required]
        [StringLength(100)]
        public ExpenseType ExpenseType { get; set; }

        [Required]
        public DateTime? Date { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be a positive value.")]
        public decimal Amount { get; set; }

        public Guid? ClientId { get; set; }

        public Guid? CaseId { get; set; }

        [StringLength(500)]
        public string Notes { get; set; }

        [Required]
        public bool IsClientPaid { get; set; }

    }
}
