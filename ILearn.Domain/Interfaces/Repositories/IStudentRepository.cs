using ILearn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILearn.Domain.Interfaces.Repositories
{
    public interface IStudentRepository
    {
        Task AddStudent(Student student);
        Task<List<Student>> GetStudents();
        Task<Student> GetStudentByEmail(string email);
        Task<Student> GetStudentByID(int id);
    }
}
