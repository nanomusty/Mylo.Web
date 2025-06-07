using System.ComponentModel.DataAnnotations;

namespace Mylo.Web.ObjectModels
{
    public class MeetingModel
    {
        public Guid Id { get; set; }
        public Guid OrganisationId { get; set; }

        [Required]
        public string MeetingType { get; set; } // Telefon, Zoom, Yüz Yüze vs.
        public Guid? RelatedContactId { get; set; } // sistemdeki kişi ya da kurumun ID'si

        [Required]
        public DateTime MeetingDate { get; set; }
        [Required]
        public DateTime? ReminderDate { get; set; } // follow-up için

        public string Topics { get; set; } // virgül ile ayrılmış etiketler
        public string Result { get; set; } // Teklif Verildi, Takip Edilecek, Red Edildi vs.

        public string Notes { get; set; } // Opsiyonel ek açıklamalar
        public bool IsActive { get; set; } = true;

        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }

        public string? ModifiedBy { get; set; }
        public DateTime? ModificationDate { get; set; }

        public string? DeletedBy { get; set; }
        public DateTime? DeletionDate { get; set; }
    }
}
