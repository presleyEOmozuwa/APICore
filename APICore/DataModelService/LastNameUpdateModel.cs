using System;
using System.ComponentModel.DataAnnotations;

namespace APICore.DataModelService
{
    public class LastNameUpdateModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}
