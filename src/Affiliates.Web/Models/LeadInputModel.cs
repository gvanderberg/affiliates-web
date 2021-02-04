using System.ComponentModel.DataAnnotations;

namespace Affiliates.Web.Models
{
    public class LeadInputModel
    {
        [Display(Name = "First name"), Required]
        public string FirstName { get; set; }

        [Display(Name = "Last name"), Required]
        public string LastName { get; set; }

        [Display(Name = "Contact number"), Required]
        public string ContactNumber { get; set; }
    }
}