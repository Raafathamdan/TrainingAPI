using System;
using System.Collections.Generic;

namespace TrainingAPI.Models;

public partial class QuestionType
{
    public int QuestionTypeId { get; set; }

    public string Name { get; set; } = null!;

    public bool? IsActive { get; set; }

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
}
