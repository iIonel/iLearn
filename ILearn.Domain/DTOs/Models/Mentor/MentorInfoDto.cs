using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILearn.Domain.DTOs.Models.Mentor
{
    public class MentorInfoDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Biography { get; set; }

        public string ProfilePictureUrl { get; set; }

        public string Email { get; set; }

        public string LinkedInUrl { get; set; }
    }
}
