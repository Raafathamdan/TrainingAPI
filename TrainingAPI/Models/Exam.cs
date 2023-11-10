using System;
using System.Collections.Generic;

namespace TrainingAPI.Models;

public partial class Exam
{
    public string Title { get; set; } = null!;

    public DateTime Date { get; set; }

    public int Mark { get; set; }

    public int QuestionCount { get; set; }

    public int Duration { get; set; }

    public bool IsPassed { get; set; }

    public string Level { get; set; } = null!;

    public int Examid { get; set; }

    public int? Userid { get; set; }

    public string? NationalityId { get; set; }

    public double? Actualmark { get; set; }

    public DateTime? Submittime { get; set; }

    public string? Notes { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Examquestion> Examquestions { get; set; } = new List<Examquestion>();

    public virtual User? User { get; set; }
}
