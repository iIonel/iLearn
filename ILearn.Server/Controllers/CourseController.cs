using ILearn.Domain.DTOs.Models.Course;
using ILearn.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ILearn.API.Controllers
{
    [Route("api/course")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost, Authorize(Roles = "Mentor")]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCourseDto dto, [FromQuery] int mentorId)
        {
            try
            {
                await _courseService.CreateCourse(dto, mentorId);
                return Ok("Created successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet, Authorize]
        public async Task<ActionResult<List<CourseInfoProfileDto>>> GetAllCourses()
        {
            try
            {
                var courses = await _courseService.GetAllCourses();
                return Ok(courses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("enroll"), Authorize(Roles = "Student")]
        public async Task<IActionResult> NewCourseEnrollment([FromBody] CourseEnrollmentDto dto)
        {
            try
            {
                await _courseService.CreateCourseEnrollment(dto);
                return Ok("Created successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("enroll"), Authorize(Roles = "Student")]
        public async Task<IActionResult> DeleteCourseEnrollment([FromBody] CourseEnrollmentDto dto)
        {
            try
            {
                await _courseService.DeleteCourseEnrollemnt(dto);
                return Ok("Deleted successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
