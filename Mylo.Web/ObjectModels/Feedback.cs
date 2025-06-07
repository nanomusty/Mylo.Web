using Mylo.Web.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace Mylo.Web.ObjectModels
{
    public class Feedback : BaseEntity
    {
        [Required]
        public FeedbackSubject Subject { get; set; }   

        public Guid OrganisationId { get; set; }
        
        [Required(ErrorMessage = "Message is required")]
        public string Message { get; set; }
        
        public FeedbackStatus Status { get; set; }
        
        public string? Response { get; set; }
        
        public DateTime? ResponseDate { get; set; }
        
        public string? RespondedBy { get; set; }
    }    
}
