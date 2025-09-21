using System;
using System.Collections.Generic;

namespace ILearn.Domain.Entities;

public partial class Chapter
{
    public int ChapterId { get; set; }

    public int CourseId { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public virtual ICollection<ChapterComment> ChapterComments { get; set; } = new List<ChapterComment>();

    public virtual Course Course { get; set; } = null!;
}
