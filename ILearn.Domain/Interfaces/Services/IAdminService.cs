using ILearn.Domain.DTOs.Models.Mentor;
using ILearn.Domain.DTOs.Models.Student;
using ILearn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILearn.Domain.Interfaces.Services
{
    public interface IAdminService
    {
        Task<List<Admin>> GetAdmins();
        Task AddValidMentor(int mentorId);
        Task DeleteMentor(int mentorId);
        Task DeleteStudent(int studentId);

    }
}
