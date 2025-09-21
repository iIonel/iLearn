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
    public class AdminRepository : IAdminRepository
    {
        private readonly ILearnDbContext DbContext;

        public AdminRepository(ILearnDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task AddValidMentor(int mentorId)
        {
            var myMentor = await DbContext.Mentors
                .SingleOrDefaultAsync(x => x.MentorId == mentorId);
            
            myMentor.IsApproved = true;
            
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteMentor(int mentorId)
        {
            var myMentor = await DbContext.Mentors
                .SingleOrDefaultAsync(x => x.MentorId == mentorId);

            var myProfile = await DbContext.MentorProfiles
                .SingleOrDefaultAsync(x => x.MentorId == myMentor.MentorId);

            if (myProfile != null)
            {
                DbContext.MentorProfiles.Remove(myProfile);
            }

            DbContext.Mentors.Remove(myMentor);
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteStudent(int studentId)
        {
            var myStudent = await DbContext.Students
                .SingleOrDefaultAsync(x => x.StudentId == studentId);

            DbContext.Students
                .Remove(myStudent);

            await DbContext.SaveChangesAsync(); 
        }

        public async Task<Admin> GetAdminByEmail(string email)
        {
            return await DbContext.Admins
                .SingleOrDefaultAsync(x => x.Email == email);
        }

        public async Task<List<Admin>> GetAdmins()
        {
            return await DbContext.Admins
                .ToListAsync();
        }
    }
}
