namespace Mylo.Web.ObjectModels
{
    public class OrganisationRegisterModel 
    {
        // Organization Details
        public string OrganisationName { get; set; }

        // Admin User Details
        public string AdminFirstName { get; set; }
        public string AdminLastName { get; set; }
        public string AdminEmail { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        // Terms and Privacy
        public bool AcceptTerms { get; set; }
        public bool AcceptPrivacy { get; set; }
    }
}
