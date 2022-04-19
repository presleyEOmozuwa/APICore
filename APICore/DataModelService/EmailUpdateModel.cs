using System;
using System.ComponentModel.DataAnnotations;

namespace APICore.DataModelService
{
    public class EmailUpdateModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
