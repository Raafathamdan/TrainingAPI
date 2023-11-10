using System;
using System.Collections.Generic;

namespace TrainingAPI.Models;

public partial class Examquestion
{
    public int Examquestionid { get; set; }

    public int? Examid { get; set; }

    public int? Questionid { get; set; }

    public bool? IsActive { get; set; }

    public virtual Exam? Exam { get; set; }

    public virtual Question? Question { get; set; }
}
