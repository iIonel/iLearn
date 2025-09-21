using System;
using System.Collections.Generic;

namespace ILearn.Domain.Entities;

public partial class CourseEnrollment
{
    public int EnrollmentId { get; set; }

    public int UserId { get; set; }

    public int CourseId { get; set; }

    public DateTime EnrollmentDate { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Student User { get; set; } = null!;
}
