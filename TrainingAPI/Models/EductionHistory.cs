using System;
using System.Collections.Generic;

namespace TrainingAPI.Models;

public partial class EductionHistory
{
    public int EductionHistoryId { get; set; }

    public string Title { get; set; } = null!;

    public string Specification { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Description { get; set; }

    public string OrginzationName { get; set; } = null!;

    public int? Userid { get; set; }

    public string? NationalityId { get; set; }

    public bool? IsActive { get; set; }

    public virtual User? User { get; set; }
}
