using ILearn.Domain.DTOs.Auth;
using ILearn.Domain.DTOs.Models.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILearn.Domain.Interfaces
{
    public interface IStudentService
    {
        Task<List<StudentDto>> GetStudents();
    }
}
