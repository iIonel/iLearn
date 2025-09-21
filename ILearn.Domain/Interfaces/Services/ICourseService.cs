using ILearn.Domain.DTOs.Models.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ILearn.Domain.Interfaces.Services
{
    public interface ICourseService
    {
        Task CreateCourse(CreateCourseDto dto, int mentorId);
        Task CreateCourseEnrollment(CourseEnrollmentDto dto);
        Task DeleteCourseEnrollemnt(CourseEnrollmentDto dto);
        Task<List<CourseInfoProfileDto>> GetAllCourses();
    }
}
