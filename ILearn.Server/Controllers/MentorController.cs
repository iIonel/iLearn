using ILearn.Domain.DTOs.Models.Mentor;
using ILearn.Domain.Interfaces;
using ILearn.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ILearn.API.Controllers
{
    [Route("api/mentor")]
    [ApiController]
    public class MentorController : ControllerBase
    {
        private readonly IMentorService _mentorService;
        private readonly IAdminService _adminService;
        public MentorController(IMentorService mentorService, IAdminService adminService)
        {
            _mentorService = mentorService;
            _adminService = adminService;
        }

        /*[HttpGet("profiles")]
        public async Task<ActionResult<List<MentorInfo>>> GetAllMentors()
        {
            try
            {
                var mentors = await _mentorService.GetAllMentors();
                return Ok(mentors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        */

        [HttpPost("search"), Authorize]
        public async Task<ActionResult<List<MentorInfoDto>>> SearchMentors([FromQuery] string term)
        {
            try
            {
                var mentors = await _mentorService.SearchMentors(term);
                return Ok(mentors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("edit"), Authorize(Roles = "Mentor")]
        public async Task<ActionResult> UpdateMentorInfo([FromBody] UpdateMentorInfoDto updateMentorInfo, [FromQuery] int id)
        {
            try
            {
                await _mentorService.UpdateMentorInfo(updateMentorInfo, id);
                return Ok("Edit successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("new-mentors"), Authorize(Roles = "Admin")]
        public async Task<ActionResult> GetAllNewMentors()
        {
            try
            {
                return Ok(await _mentorService.GetNewMentors());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet, Authorize]
        public async Task<ActionResult> GetAllValidMentors()
        {
            try
            {
                return Ok(await _mentorService.GetValidMentors());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<ActionResult> AddMentor([FromQuery] int mentorId)
        {
            try
            {
                await _adminService.AddValidMentor(mentorId);
                return Ok("Mentor validation successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete, Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteMentor([FromQuery] int mentorId)
        {
            try
            {
                await _adminService.DeleteMentor(mentorId);
                return Ok("Mentor deleted successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
