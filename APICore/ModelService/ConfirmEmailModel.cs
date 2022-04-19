using System;
using System.ComponentModel.DataAnnotations;

namespace APICore.ModelService
{
    public class ConfirmEmailModel
    {
        [Required]
        public string Token { get; set; }
        [Required]
        public string Id { get; set; }
    }
}
