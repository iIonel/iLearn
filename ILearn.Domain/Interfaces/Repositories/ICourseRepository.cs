using ILearn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILearn.Domain.Interfaces.Repositories
{
    public interface ICourseRepository
    {
        Task AddCourse(Course course);
        Task<List<Course>> GetAllCourses();
        Task AddCourseEnrollment(CourseEnrollment courseEnrollment);
        Task DeleteCourseEnrollment(CourseEnrollment courseEnrollment);
    }
}
