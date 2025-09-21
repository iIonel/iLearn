using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILearn.Domain.DTOs.Models.Course
{
    public class CourseEnrollmentDto
    {
        public int UserId { get; set; }

        public int CourseId { get; set; }
    }
}
