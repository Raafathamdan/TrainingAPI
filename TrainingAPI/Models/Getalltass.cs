using System;
using System.Collections.Generic;

namespace TrainingAPI.Models;

public partial class Getalltass
{
    public int Taskid { get; set; }

    public string Title { get; set; } = null!;

    public DateTime DeadLine { get; set; }

    public int DurationHours { get; set; }

    public double Mark { get; set; }

    public string FullName { get; set; } = null!;

    public int? Students { get; set; }

    public double? Avg { get; set; }
}
