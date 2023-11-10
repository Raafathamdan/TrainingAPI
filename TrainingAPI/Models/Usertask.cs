using System;
using System.Collections.Generic;

namespace TrainingAPI.Models;

public partial class Usertask
{
    public int Usertasksid { get; set; }

    public int? Userid { get; set; }

    public string? NationalityId { get; set; }

    public int? Taskid { get; set; }

    public double? Actualmark { get; set; }

    public DateTime? Submittime { get; set; }

    public string? Notes { get; set; }

    public bool? IsActive { get; set; }

    public virtual Task? Task { get; set; }

    public virtual User? User { get; set; }
}
