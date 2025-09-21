using ILearn.Domain.DTOs.Models;
using ILearn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILearn.Domain.Interfaces.Repositories
{
    public interface IMentorRepository
    {
        Task AddMentor(Mentor mentor);
        Task<Mentor> GetMentorByEmail(string email);
        Task<Mentor> GetMentorById(int id);
        Task AddProfile(MentorProfile profile);
        Task<List<Mentor>> GetAllValidMentors();
        Task<List<Mentor>> GetAllNewMentors();
        Task<List<MentorProfile>> SearchMentors(string term);
        Task UpdateMentorInfo(MentorProfile profile, string? bioghraphy, string? picture);
        Task<MentorProfile> GetMentorProfileByMentor(Mentor mentor);
    }
}
