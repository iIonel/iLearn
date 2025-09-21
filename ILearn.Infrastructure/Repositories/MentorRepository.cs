using ILearn.Domain.DTOs.Models;
using ILearn.Domain.Entities;
using ILearn.Domain.Interfaces.Repositories;
using ILearn.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILearn.Infrastructure.Repositories
{
    public class MentorRepository : IMentorRepository
    {
        private readonly ILearnDbContext DbContext;

        public MentorRepository(ILearnDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task AddMentor(Mentor mentor)
        {
            DbContext.Mentors.Add(mentor);
            await DbContext.SaveChangesAsync();
        }

        public async Task AddProfile(MentorProfile profile)
        {
            DbContext.MentorProfiles.Add(profile);
            await DbContext.SaveChangesAsync();
        }

        public async Task<List<Mentor>> GetAllNewMentors()
        {
            return await DbContext.Mentors
                .Where(x => x.IsApproved == false)
                .ToListAsync();
        }

        public async Task<List<Mentor>> GetAllValidMentors()
        {
           return await DbContext.Mentors
                .Where(x => x.IsApproved == true)
                .ToListAsync();
        }

        public async Task<Mentor> GetMentorByEmail(string email)
        {
            return await DbContext.Mentors
                .SingleOrDefaultAsync(x => x.Email == email);
        }

        public async Task<MentorProfile> GetMentorProfileByMentor(Mentor mentor)
        {
            return await DbContext.MentorProfiles
                .SingleOrDefaultAsync(x => x.MentorId == mentor.MentorId);
        }

        public async Task<Mentor> GetMentorById(int id)
        {
            return await DbContext.Mentors
                .SingleOrDefaultAsync(x => x.MentorId == id);
        }

        public async Task<List<MentorProfile>> SearchMentors(string term)
        {
            var validMentors = await GetAllValidMentors();
            var mentors = await DbContext.MentorProfiles
                         .Include(x => x.Mentor)
                         .Where(x => (x.Mentor.FirstName + " " + x.Mentor.LastName).Contains(term))
                         .ToListAsync();

       
            var profiles = mentors
                .Where(x => validMentors.Any(v => v.MentorId == x.MentorId))
                .ToList();

            return profiles;
        }

        public async Task UpdateMentorInfo(MentorProfile profile, string? biography, string? picture)
        {
            var validMentors = await GetAllValidMentors();
            if (validMentors.Any(v => v.MentorId == profile.MentorId))
            {
             
                if (!string.IsNullOrEmpty(biography))
                {
                    profile.Biography = biography;
                }

                if (!string.IsNullOrEmpty(picture))
                {
                    profile.ProfilePictureUrl = picture;
                }

                await DbContext.SaveChangesAsync();
            }
        }
    }
}
