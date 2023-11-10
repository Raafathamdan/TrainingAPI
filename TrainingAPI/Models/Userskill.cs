using System;
using System.Collections.Generic;

namespace TrainingAPI.Models;

public partial class Userskill
{
    public int Userskills { get; set; }

    public int? Userid { get; set; }

    public string? NationalityId { get; set; }

    public int? Skillsid { get; set; }

    public bool? IsActive { get; set; }

    public virtual Skill? Skills { get; set; }

    public virtual User? User { get; set; }
}
