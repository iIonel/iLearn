using ILearn.Domain.DTOs.Auth;
using ILearn.Domain.DTOs.Models.Mentor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILearn.Domain.Interfaces
{
    public interface IMentorService
    {
        Task<List<MentorInfoDto>> SearchMentors(string term);
        Task UpdateMentorInfo(UpdateMentorInfoDto dto, int mentorId);

        Task<List<MentorDto>> GetValidMentors();
        Task<List<MentorDto>> GetNewMentors();
    }
}
