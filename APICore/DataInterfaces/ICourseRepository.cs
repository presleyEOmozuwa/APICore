using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APICore.DataModelService;
using APICore.ModelService;
using Stripe;

namespace APICore.DataInterfaces
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetCourseList();
        Task<Course> GetCourseById(string courseId);
        Task<Course> CreateCourse(Course course);
        Task<Course> UpdateCourse(Course course);
        Task DeleteCourse(Course course);
    }
}
