using System;
using System.Collections.Generic;

namespace ILearn.Domain.Entities;

public partial class ChapterComment
{
    public int CommentId { get; set; }

    public int ChapterId { get; set; }

    public int UserId { get; set; }

    public string CommentText { get; set; } = null!;

    public DateTime CommentDate { get; set; }

    public virtual Chapter Chapter { get; set; } = null!;

    public virtual Student User { get; set; } = null!;
}
