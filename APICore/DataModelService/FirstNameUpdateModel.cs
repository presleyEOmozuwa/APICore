using System;
using System.ComponentModel.DataAnnotations;

namespace APICore.DataModelService
{
    public class FirstNameUpdateModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
    }
}
