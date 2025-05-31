namespace Mylo.Web.ObjectModels
{
    public class ContactCard : BaseEntity
    {
        public Guid OrganisationId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Company { get; set; }
        public string? JobTitle { get; set; }
        public string? Address { get; set; }
        public string? Website { get; set; }
        public string? Notes { get; set; }
        public string? ProfileImageUrl { get; set; }
    }
}
