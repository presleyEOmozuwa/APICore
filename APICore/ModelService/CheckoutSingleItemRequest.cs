using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APICore.ModelService
{
    public class CheckoutSingleItemRequest
    {
        [Required]
        public string PriceId { get; set; }
        [Required]
        public string SuccessUrl { get; set; }
        [Required]
        public string FailureUrl { get; set; }
    }
}
