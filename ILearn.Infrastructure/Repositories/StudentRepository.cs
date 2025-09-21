using ILearn.Domain.Entities;
using ILearn.Domain.Interfaces.Repositories;
using ILearn.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILearn.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ILearnDbContext DbContext;

        public StudentRepository(ILearnDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task AddStudent(Student student)
        {
            DbContext.Students.Add(student);
            await DbContext.SaveChangesAsync();
        }

        public async Task<Student> GetStudentByEmail(string email)
        {
            return await DbContext.Students
                .SingleOrDefaultAsync(x => x.Email == email);
        }

        public async Task<Student> GetStudentByID(int id)
        {
            return await DbContext.Students
                .SingleOrDefaultAsync(x => x.StudentId == id);
        }

        public async Task<List<Student>> GetStudents()
        {
            return await DbContext.Students.ToListAsync();
        }
    }
}
