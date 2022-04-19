using System;
using System.ComponentModel.DataAnnotations;

namespace APICore.DataModelService
{
    public class UserNameUpdateModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string UserName { get; set; }
    }
}
