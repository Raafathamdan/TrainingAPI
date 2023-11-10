using System;
using System.Collections.Generic;

namespace TrainingAPI.Models;

public partial class Joptitle
{
    public string Name { get; set; } = null!;

    public string Desc { get; set; } = null!;

    public string? Requirements { get; set; }

    public int? MinSalary { get; set; }

    public int? MaxSalary { get; set; }

    public int ExpirencesTime { get; set; }

    public string Tasks { get; set; } = null!;

    public string Conditions { get; set; } = null!;

    public int Level { get; set; }

    public int Joptitleid { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
}
