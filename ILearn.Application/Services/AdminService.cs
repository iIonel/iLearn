using ILearn.Domain.DTOs.Models.Mentor;
using ILearn.Domain.DTOs.Models.Student;
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
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IMentorRepository _mentorRepository;
        private readonly IStudentRepository _studentRepository;

        public AdminService(IAdminRepository adminRepository, IMentorRepository mentorRepository, IStudentRepository studentRepository)
        {
            _adminRepository = adminRepository;
            _mentorRepository = mentorRepository;
            _studentRepository = studentRepository;
        }

        public async Task<List<Admin>> GetAdmins()
        {
            var admins = await _adminRepository.GetAdmins();
            return admins;
        }

        public async Task AddValidMentor(int mentorId)
        {
            var mentors = await _mentorRepository.GetAllNewMentors();
            
            bool isMentor = mentors.Any(x => x.MentorId == mentorId);
           
            if (isMentor)
            {
                await _adminRepository.AddValidMentor(mentorId);
                var mentor = await _mentorRepository.GetMentorById(mentorId);
                
                var profile = new MentorProfile
                { 
                    MentorId = mentor.MentorId,
                    Email = mentor.Email,
                    LinkedInUrl = mentor.LinkedInUrl
                };
                await _mentorRepository.AddProfile(profile);
            }
        }

        public async Task DeleteMentor(int mentorId)
        {
            await _adminRepository.DeleteMentor(mentorId);
        }

        public async Task DeleteStudent(int studentId)
        {
            await _adminRepository.DeleteStudent(studentId);
        }

    }
}
