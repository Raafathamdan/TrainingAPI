using System;
using System.Collections.Generic;

namespace TrainingAPI.Models;

public partial class AllTask
{
    public string Title { get; set; } = null!;

    public DateTime Date { get; set; }

    public int DurationHours { get; set; }

    public double Mark { get; set; }

    public string Conditions { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Requirements { get; set; } = null!;

    public DateTime DeadLine { get; set; }

    public bool IsPassed { get; set; }

    public string Level { get; set; } = null!;

    public int Taskid { get; set; }

    public bool? IsActive { get; set; }
}
