using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILearn.Domain.DTOs.Models.Course
{
    public class UpdateCourseInfoDto
    {
        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public string? DemoUrl { get; set; }

        public string? Requirements { get; set; }

        public bool Done { get; set; }
    }
}
