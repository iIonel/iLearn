using System;
using System.Collections.Generic;

namespace ILearn.Domain.Entities;

public partial class MentorProfile
{
    public int MentorProfileId { get; set; }

    public int MentorId { get; set; }

    public string? Biography { get; set; }

    public string? ProfilePictureUrl { get; set; }

    public string? Email { get; set; }

    public string? LinkedInUrl { get; set; }

    public virtual Mentor Mentor { get; set; } = null!;
}
