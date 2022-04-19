using System;
using System.ComponentModel.DataAnnotations;

namespace APICore.ModelService
{
    public class CustomerPortalRequest
    {
        [Required]
        public string ReturnUrl { get; set; }
    }
}
