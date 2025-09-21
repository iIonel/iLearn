using ILearn.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILearn.Application.Utilities
{
    public static class EmailValidator
    {
        public static async Task<bool> EmailExists(string email, IStudentRepository studentRepository, IMentorRepository mentorRepository, IAdminRepository adminRepository)
        {
            var mentorExists = await mentorRepository.GetMentorByEmail(email);
            var studentExists = await studentRepository.GetStudentByEmail(email);
            var adminExists = await adminRepository.GetAdminByEmail(email); 

            return mentorExists != null || studentExists != null || adminExists != null;
        }
    }
}
