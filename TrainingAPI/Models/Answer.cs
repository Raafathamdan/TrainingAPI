using System;
using System.Collections.Generic;

namespace TrainingAPI.Models;

public partial class Answer
{
    public int Id { get; set; }

    public bool Iscorrect { get; set; }

    public string Title { get; set; } = null!;

    public int? QuestionId { get; set; }

    public bool? IsActive { get; set; }

    public virtual Question? Question { get; set; }
}
