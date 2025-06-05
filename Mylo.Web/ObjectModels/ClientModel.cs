using Mylo.Web.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace Mylo.Web.ObjectModels
{
    public class ClientModel : BaseEntity
    {
        public Guid OrganisationId { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; }

        [Phone]
        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        [StringLength(100)]
        public string City { get; set; }

        [StringLength(100)]
        public string Country { get; set; }

        [StringLength(20)]
        public string PostalCode { get; set; }

        public ClientType ClientType { get; set; }

        public int CaseCount { get; set; }

        [StringLength(200)]
        public string CompanyName { get; set; }

        [StringLength(50)]
        public string TaxNumber { get; set; }

        [StringLength(20)]
        public string IdentityNumber { get; set; }

        public string Notes { get; set; }

        public bool IsActive { get; set; }

        // Computed property for full name
        public string FullName => $"{FirstName} {LastName}";
    }
} 