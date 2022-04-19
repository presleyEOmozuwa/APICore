using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APICore.ModelService
{
    public class CheckoutItemListRequest
    {
        [Required]
        public List<string> PriceIds { get; set; }
        [Required]
        public string SuccessUrl { get; set; }
        [Required]
        public string FailureUrl { get; set; }
    }
}
