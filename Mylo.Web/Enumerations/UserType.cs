using System.ComponentModel.DataAnnotations;

namespace Mylo.Web.Enumerations
{
    public enum UserType : int
    {
        None = -1,
        Normal = 0,
        Administrator = 1,

        [Display(Name = "Super Administrator")]
        SuperAdministrator = 99

    }
}
