using ILearn.Domain.DTOs.Auth;
using ILearn.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILearn.Domain.Interfaces.Services
{
    public interface IAuthService
    {
        Task RegisterMentor(RegisterMentorDto dto);
        Task RegisterStudent(RegisterStudentDto dto);
        Task<(int?, Roles?)> Login(LoginUserDto dto);
    }
}
