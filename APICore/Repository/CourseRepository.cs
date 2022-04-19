using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICore.DataInterfaces;
using APICore.DataModelService;
using APICore.DataService;
using APICore.ModelService;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace APICore.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Course>> GetCourseList()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course> GetCourseById(string courseId)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.CourseId == courseId);

            if (course != null)
            {
                return course;
            }

            return new Course();
        }


        public async Task<Course> CreateCourse(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task<Course> UpdateCourse(Course course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task DeleteCourse(Course course)
        {
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }

    }
}
