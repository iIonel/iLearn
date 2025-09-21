using ILearn.Domain.DTOs.Auth;
using ILearn.Domain.Entities;
using ILearn.Domain.Interfaces;
using ILearn.Domain.Interfaces.Repositories;
using ILearn.Domain.Interfaces.Services;
using ILearn.Application.Utilities; 
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Bcpg;
using Org.BouncyCastle.Crypto.Generators;
using ILearn.Application.Helpers;
using Microsoft.AspNetCore.Http;
using ILearn.Domain.Enums;

namespace ILearn.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IMentorRepository _mentorRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IAdminRepository _adminRepository;

        public AuthService(IStudentRepository studentRepository, IMentorRepository mentorRepository, IAdminRepository adminRepository)
        {
            _mentorRepository = mentorRepository;
            _studentRepository = studentRepository;
            _adminRepository = adminRepository;
        }

        public async Task<(int?,Roles?)> Login(LoginUserDto dto)
        {
            var student = await _studentRepository.GetStudentByEmail(dto.Email);
            var mentor = await _mentorRepository.GetMentorByEmail(dto.Email);
            var admin = await _adminRepository.GetAdminByEmail(dto.Email);

            if (student == null && mentor == null && admin == null)
            {
                throw new ArgumentException("User not found.");
            }
            else if (student != null && BCrypt.Net.BCrypt.Verify(dto.Password, student.PasswordHash))
            {
                Roles role = Roles.Student;
                return (student.StudentId, role);
            }
            else if (mentor != null && BCrypt.Net.BCrypt.Verify(dto.Password, mentor.PasswordHash) && mentor.IsApproved == true)
            {
                Roles role = Roles.Mentor;
                return (mentor.MentorId, role);
            }
            else if (admin != null && BCrypt.Net.BCrypt.Verify(dto.Password, admin.PasswordHash))
            {
                Roles role = Roles.Admin;
                return (admin.AdminId, role);
            }

            throw new ArgumentException("Invalid credentials.");
        }

        public async Task RegisterMentor(RegisterMentorDto dto)
        {
            if (await EmailValidator.EmailExists(dto.Email, _studentRepository, _mentorRepository, _adminRepository))
            {
                throw new ArgumentException("A user with this email already exists.");
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            var mentor = new Mentor
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PasswordHash = passwordHash,
                LinkedInUrl = dto.LinkedInUrl,
                HireDate = DateTime.UtcNow
            };


            await _mentorRepository.AddMentor(mentor);

            /*var profile = new MentorProfile
            {
                MentorId = mentor.MentorId,
                Email = mentor.Email,
                LinkedInUrl = mentor.LinkedInUrl
            };

            await _mentorRepository.AddProfile(profile);
            */
        }

        public async Task RegisterStudent(RegisterStudentDto dto)
        {
            if (await EmailValidator.EmailExists(dto.Email, _studentRepository, _mentorRepository, _adminRepository))
            {
                throw new ArgumentException("A user with this email already exists.");
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);   

            var student = new Student
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PasswordHash = passwordHash,
                EnrollmentDate = DateTime.UtcNow
            };

            await _studentRepository.AddStudent(student);
        }
    }
}
