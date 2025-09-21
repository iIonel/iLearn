using ILearn.Domain.Entities;
using ILearn.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using ILearn.Domain.Interfaces.Repositories;
using ILearn.Domain.DTOs.Auth;
using System.Runtime.CompilerServices;
using ILearn.Domain.DTOs.Models.Mentor;

namespace ILearn.Application.Services
{
    public class MentorService : IMentorService
    {
        private readonly IMentorRepository _mentorRepository;

        public MentorService(IMentorRepository mentorRepository)
        {
            this._mentorRepository = mentorRepository;
        }

       /* public async Task<List<MentorInfo>> GetAllMentors()
        {
            var profiles = await _mentorRepository.GetAllValidMentors();
            return profiles.Select(x => new MentorInfo
            {
                FirstName = x.Mentor.FirstName,
                LastName = x.Mentor.LastName,
                Email = x.Mentor.Email,
                LinkedInUrl = x.LinkedInUrl,
                Biography = x.Biography,
                ProfilePictureUrl = x.ProfilePictureUrl
            }).ToList();
        }*/

        public async Task<List<MentorInfoDto>> SearchMentors(string term)
        {
            var profiles = await _mentorRepository.SearchMentors(term);
            return profiles.Select(x => new MentorInfoDto
            {
                FirstName = x.Mentor.FirstName,
                LastName = x.Mentor.LastName,
                Email = x.Mentor.Email,
                LinkedInUrl = x.LinkedInUrl,
                Biography = x.Biography,
                ProfilePictureUrl = x.ProfilePictureUrl
            }).ToList();
        }
      
        public async Task UpdateMentorInfo(UpdateMentorInfoDto updateMentorInfo, int id)
        {
            var mentor = await _mentorRepository.GetMentorById(id);
            var profile = await _mentorRepository.GetMentorProfileByMentor(mentor);
            
            await _mentorRepository.UpdateMentorInfo(profile, updateMentorInfo.Biography, updateMentorInfo.ProfilePictureUrl);
        }

        public async Task<List<MentorDto>> GetValidMentors()
        {
            var mentors = await _mentorRepository.GetAllValidMentors();
            return mentors.Select(x => new MentorDto
            {
                Id = x.MentorId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                LinkedInUrl = x.LinkedInUrl
            }).ToList();
        }

        public async Task<List<MentorDto>> GetNewMentors()
        {
            var mentors = await _mentorRepository.GetAllNewMentors();
            return mentors.Select(x => new MentorDto
            {
                Id = x.MentorId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                LinkedInUrl = x.LinkedInUrl
            }).ToList();
        }
    }
}
