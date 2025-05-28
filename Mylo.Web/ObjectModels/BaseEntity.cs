using System.ComponentModel.DataAnnotations;

namespace Mylo.Web.ObjectModels
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Display(Name ="Is Active?")]
        public bool IsActive { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletionDate { get; set; }
    }
}
