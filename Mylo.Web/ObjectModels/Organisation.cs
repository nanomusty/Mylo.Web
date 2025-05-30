using Mylo.Web.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace Mylo.Web.ObjectModels
{
    public class Organisation : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public PriceTier PriceTier { get; set; }
    }
}
