using System.ComponentModel.DataAnnotations;

namespace Mylo.Web.ObjectModels
{
    public class Group : BaseEntity
    {
        [Required]
        public Guid OrganisationId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
