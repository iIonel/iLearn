using System;
using System.Collections.Generic;

namespace ILearn.Domain.Entities;

public partial class Course
{
    public int CourseId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public string? DemoUrl { get; set; }

    public string DifficultyLevel { get; set; } = null!;

    public string? Requirements { get; set; }

    public int MentorId { get; set; }

    public bool Done { get; set; }

    public virtual ICollection<Chapter> Chapters { get; set; } = new List<Chapter>();

    public virtual ICollection<CourseEnrollment> CourseEnrollments { get; set; } = new List<CourseEnrollment>();

    public virtual Mentor Mentor { get; set; } = null!;
}
