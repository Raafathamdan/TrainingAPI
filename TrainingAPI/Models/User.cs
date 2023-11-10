using System;
using System.Collections.Generic;

namespace TrainingAPI.Models;

public partial class User
{
    public string FullName { get; set; } = null!;

    public int Age { get; set; }

    public string Specification { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string NationalityId { get; set; } = null!;

    public string UserType { get; set; } = null!;

    public string Bio { get; set; } = null!;

    public string? PersonalPhoto { get; set; }

    public string Adress { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Phonenumber { get; set; } = null!;

    public int Userid { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<EductionHistory> EductionHistories { get; set; } = new List<EductionHistory>();

    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

    public virtual ICollection<Expierince> Expierinces { get; set; } = new List<Expierince>();

    public virtual ICollection<Userskill> Userskills { get; set; } = new List<Userskill>();

    public virtual ICollection<Usertask> Usertasks { get; set; } = new List<Usertask>();
}
