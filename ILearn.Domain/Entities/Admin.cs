using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILearn.Domain.Entities
{
    public class Admin
    {
        public int AdminId { get; set; } 

        public string FullName { get; set; } = null!; 

        public string Email { get; set; } = null!; 

        public string PasswordHash { get; set; } = null!; 

        public DateTime CreatedAt { get; set; } 
    }
}
