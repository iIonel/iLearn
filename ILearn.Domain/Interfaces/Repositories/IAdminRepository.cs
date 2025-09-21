using ILearn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILearn.Domain.Interfaces.Repositories
{
    public interface IAdminRepository
    {
        Task<List<Admin>> GetAdmins ();
        Task<Admin> GetAdminByEmail(string email);
        Task AddValidMentor(int mentorId);
        Task DeleteMentor(int mentorId);
        Task DeleteStudent(int studentId);
    }
}
