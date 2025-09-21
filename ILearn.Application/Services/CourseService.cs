using ILearn.Domain.DTOs.Models.Course;
using ILearn.Domain.Entities;
using ILearn.Domain.Interfaces.Repositories;
using ILearn.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILearn.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMentorRepository _mentorRepository;

        public CourseService(ICourseRepository courseRepository, IMentorRepository mentorRepository)
        {
            _courseRepository = courseRepository;
            _mentorRepository = mentorRepository;
        }

        public async Task CreateCourse(CreateCourseDto dto, int mentorId)
        {
            var mentor = await _mentorRepository.GetMentorById(mentorId);
            if (mentor == null || !mentor.IsApproved.GetValueOrDefault())
                throw new Exception("Invalid Mentor");

            var newCourse = new Course
            {
                Title = dto.Title,
                Description = dto.Description,
                DifficultyLevel = dto.DifficultyLevel,
                ImageUrl = dto.ImageUrl,
                DemoUrl = dto.DemoUrl,
                Requirements = dto.Requirements,
                MentorId = mentor.MentorId,
                Done = false
            };

            await _courseRepository.AddCourse(newCourse);
        }

        public async Task CreateCourseEnrollment(CourseEnrollmentDto dto)
        {
            var newEnrollment = new CourseEnrollment
            {
                UserId = dto.UserId,
                CourseId = dto.CourseId,
                EnrollmentDate = DateTime.UtcNow
            };

            await _courseRepository.AddCourseEnrollment(newEnrollment);
        }

        public async Task DeleteCourseEnrollemnt(CourseEnrollmentDto dto)
        {
            var enrollment = new CourseEnrollment
            {
                UserId = dto.UserId,
                CourseId = dto.CourseId,
                EnrollmentDate = DateTime.UtcNow
            };

            await _courseRepository.DeleteCourseEnrollment(enrollment);
        }

        public async Task<List<CourseInfoProfileDto>> GetAllCourses()
        {
            var courses = await _courseRepository.GetAllCourses();
            var coursesProfiles = new List<CourseInfoProfileDto>();
            foreach(var courseProfile in courses)
            {
                var mentorId = courseProfile.MentorId;
                var mentor = await _mentorRepository.GetMentorById(mentorId);
                var fullName = mentor.FirstName + " " + mentor.LastName;

                var courseInfoProfile = new CourseInfoProfileDto
                {
                    CourseId = courseProfile.CourseId,
                    Title = courseProfile.Title,
                    ImageUrl = courseProfile.ImageUrl,
                    Author = fullName,
                    DifficultyLevel = courseProfile.DifficultyLevel,
                };

                coursesProfiles.Add(courseInfoProfile);
            }

            return coursesProfiles;
        }
    }
}
