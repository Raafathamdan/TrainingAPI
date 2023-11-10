using System;
using System.Collections.Generic;

namespace TrainingAPI.Models;

public partial class Expierince
{
    public string? Title { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? Enddate { get; set; }

    public string? Description { get; set; }

    public string? CompanyName { get; set; }

    public int ExpierincesId { get; set; }

    public int? Userid { get; set; }

    public string? NationalityId { get; set; }

    public bool? Isactive { get; set; }

    public virtual User? User { get; set; }
}
