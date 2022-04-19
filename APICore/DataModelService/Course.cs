using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using APICore.ModelService;

namespace APICore.DataModelService
{
    public class Course
    {
        [Key]
        public string CourseId { get; set; }
        public string PriceId { get; set; }
        public double Price { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public virtual IList<CourseCart> CourseCarts { get; set; } = new List<CourseCart>();
    }
}
