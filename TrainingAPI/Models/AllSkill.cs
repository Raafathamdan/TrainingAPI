using System;
using System.Collections.Generic;

namespace TrainingAPI.Models;

public partial class AllSkill
{
    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Rate { get; set; } = null!;

    public int Skillsid { get; set; }

    public bool? Isactive { get; set; }
}
