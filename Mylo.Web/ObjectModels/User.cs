﻿using Mylo.Web.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace Mylo.Web.ObjectModels
{
    public class User : BaseEntity
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public UserType UserType { get; set; }

        public Guid OrganisationId { get; set; }

        public string? Captcha { get; set; }
    }
}
