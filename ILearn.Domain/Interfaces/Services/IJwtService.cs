using ILearn.Domain.Enums;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILearn.Domain.Interfaces.Services
{
    public interface IJwtService
    {
        Task<string> CreateToken(int id, Roles role, IConfiguration configuration);
    }
}
