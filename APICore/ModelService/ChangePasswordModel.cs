using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICore.ModelService
{
    public class ChangePasswordModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [NotMapped]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 8)]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [NotMapped]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match")]
        public string ConfirmPassword { get; set; }
    }
}
