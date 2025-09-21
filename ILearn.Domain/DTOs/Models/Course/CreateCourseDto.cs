using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILearn.Domain.DTOs.Models.Course
{
    public class CreateCourseDto
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string DifficultyLevel { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public string? DemoUrl { get; set; }
        public string? Requirements { get; set; }
    }
}