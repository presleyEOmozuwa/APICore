using System;
using APICore.DataModelService;
using Microsoft.AspNetCore.Identity;

namespace APICore.DataModelService
{
    public class ApplicationUser : IdentityUser
    {
        public string CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual Cart Cart { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}
