using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace APICore.ModelService
{
    public class EmailRequest
    {
        [Required]
        public string ToEmail { get; set; }

        [Required]
        public string ToName { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string CallBackUrl { get; set; }

        [Required]
        public string EmailFilePath { get; set; }

        public List<IFormFile> Attachments { get; set; }
    }
}
