using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICore.DataModelService
{
    public class AppUserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string CreatedAt { get; set; } = DateTime.Now.ToString("F");
        public string UpdatedAt { get; set; } = "No Update Yet";
    }
}