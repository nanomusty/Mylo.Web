using Mylo.Web.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace Mylo.Web.ObjectModels
{
    public class CaseModel : BaseEntity
    {
        public Guid OrganisationId { get; set; }

        [Required]
        [StringLength(100)]
        public string CaseNumber { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        public Guid ClientId { get; set; }
        
        public string ClientName { get; set; }

        public Guid? OpposingPartyId { get; set; }
        
        public string OpposingPartyName { get; set; }

        [Required]
        public CaseType CaseType { get; set; }

        [Required]
        public CaseStatus CaseStatus { get; set; }

        [StringLength(500, ErrorMessage = "Description can't be longer than 500 characters")]
        public string Description { get; set; }

        public DateTime? FilingDate { get; set; }

        public DateTime? ClosingDate { get; set; }

        [StringLength(100)]
        public string CourtName { get; set; }

        [StringLength(100)]
        public string JudgeName { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Case value must be a positive number")]
        [StringLength(100)]
        public string CaseValue { get; set; }

        [StringLength(1000)]
        public string Notes { get; set; }

        // Assigned attorney or responsible person
        public Guid? AssignedToId { get; set; }
        
        public string AssignedToName { get; set; }

        // Next hearing date
        public DateTime? NextHearingDate { get; set; }

        // Upcoming deadline
        public DateTime? NextDeadline { get; set; }
        
        public string NextDeadlineDescription { get; set; }

        public Guid? GroupId { get; set; }

        public string GroupName { get; set; }
    }
} 