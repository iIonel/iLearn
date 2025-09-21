using System;
using System.Collections.Generic;

namespace ILearn.Domain.Entities;

public partial class Mentor
{
    public int MentorId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? LinkedInUrl { get; set; }

    public bool? IsApproved { get; set; }

    public DateTime? HireDate { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<MentorProfile> MentorProfiles { get; set; } = new List<MentorProfile>();
}
