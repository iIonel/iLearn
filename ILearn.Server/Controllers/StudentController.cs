using ILearn.Domain.DTOs.Models.Student;
using ILearn.Domain.Interfaces;
using ILearn.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ILearn.API.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IAdminService _adminService;

        public StudentController(IStudentService studentService, IAdminService adminService)
        {
            _studentService = studentService;
            _adminService = adminService; 
        }

        [HttpGet, Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<StudentDto>>> GetStudents()
        {
            try
            {
                return Ok(await _studentService.GetStudents());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete, Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteStudent([FromQuery] int studentId)
        {
            try
            {
                await _adminService.DeleteStudent(studentId);
                return Ok("Student deleted successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
