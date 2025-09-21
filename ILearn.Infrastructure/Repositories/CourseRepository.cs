using ILearn.Domain.Entities;
using ILearn.Domain.Interfaces.Repositories;
using ILearn.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILearn.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ILearnDbContext DbContext;

        public CourseRepository(ILearnDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task AddCourse(Course course)
        {
            DbContext.Courses.Add(course);
            await DbContext.SaveChangesAsync();
        }

        public async Task AddCourseEnrollment(CourseEnrollment courseEnrollment)
        {
            DbContext.CourseEnrollments.Add(courseEnrollment);
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteCourseEnrollment(CourseEnrollment courseEnrollment)
        {
            DbContext.CourseEnrollments.Remove(courseEnrollment);
            await DbContext.SaveChangesAsync();
        }

        public async Task<List<Course>> GetAllCourses()
        {
            return await DbContext.Courses
                .Where(x => x.Done == true)
                .ToListAsync();
        }
    }
}
