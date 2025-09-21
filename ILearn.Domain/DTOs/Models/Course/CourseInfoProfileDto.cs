using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILearn.Domain.DTOs.Models.Course
{
    public class CourseInfoProfileDto
    {
        public int CourseId { get; set; }

        public string Title { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public string Author {  get; set; }

        public string DifficultyLevel { get; set; } = null!;
    }
}
