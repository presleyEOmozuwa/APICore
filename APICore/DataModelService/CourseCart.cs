using System;
using System.ComponentModel.DataAnnotations;

namespace APICore.DataModelService
{
    public class CourseCart
    {
        [Key]
        public string CourseCartId { get; set; }

        public int CartId { get; set; }
        public virtual Cart Cart { get; set; }

        public string CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}