using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using APICore.ModelService;

namespace APICore.DataModelService
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }

        public string DateCreated { get; set; }

        public virtual IList<CourseCart> CourseCarts { get; set; } = new List<CourseCart>();
    }
}
