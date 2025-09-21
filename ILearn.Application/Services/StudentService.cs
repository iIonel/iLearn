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
using ILearn.Domain.DTOs.Models.Student;
using ILearn.Domain.DTOs.Models.Mentor;

namespace ILearn.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<StudentDto>> GetStudents()
        {
            var students = await _studentRepository.GetStudents();
            return students.Select(x => new StudentDto
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email
            }).ToList();
        }
    }
}
