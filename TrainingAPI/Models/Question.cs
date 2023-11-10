using System;
using System.Collections.Generic;

namespace TrainingAPI.Models;

public partial class Question
{
    public string Title { get; set; } = null!;

    public string? ImagePath { get; set; }

    public string? Link { get; set; }

    public string Description { get; set; } = null!;

    public int QuestionId { get; set; }

    public int? QuestionTypeId { get; set; }

    public int? Joptitleid { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    public virtual ICollection<Examquestion> Examquestions { get; set; } = new List<Examquestion>();

    public virtual Joptitle? Joptitle { get; set; }

    public virtual QuestionType? QuestionType { get; set; }
}
