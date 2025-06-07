using System.ComponentModel.DataAnnotations;

namespace Mylo.Web.ObjectModels
{
    public class DebtorModel : BaseEntity
    {
        public Guid OrganisationId { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(20)]
        public string IdentityNumber { get; set; }

        [StringLength(50)]
        public string TaxNumber { get; set; }

        [StringLength(200)]
        public string CompanyName { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        [StringLength(1000)]
        public string Notes { get; set; }

        public bool IsActive { get; set; }

        // Computed property for full name
        public string FullName => $"{FirstName} {LastName}";
    }
}
