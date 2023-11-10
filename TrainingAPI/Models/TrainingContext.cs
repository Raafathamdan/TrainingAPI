using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TrainingAPI.Models;

public partial class TrainingContext : DbContext
{
    public TrainingContext()
    {
    }

    public TrainingContext(DbContextOptions<TrainingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AllSkill> AllSkills { get; set; }

    public virtual DbSet<AllTask> AllTasks { get; set; }

    public virtual DbSet<Answer> Answers { get; set; }

    public virtual DbSet<EductionHistory> EductionHistories { get; set; }

    public virtual DbSet<Exam> Exams { get; set; }

    public virtual DbSet<Examquestion> Examquestions { get; set; }

    public virtual DbSet<Expierince> Expierinces { get; set; }

    public virtual DbSet<Getalltask> Getalltasks { get; set; }

    public virtual DbSet<Getalltass> Getalltasses { get; set; }

    public virtual DbSet<Joptitle> Joptitles { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<QuestionType> QuestionTypes { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Userskill> Userskills { get; set; }

    public virtual DbSet<Usertask> Usertasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ADOON-PC;Initial Catalog=Training;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<AllSkill>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("AllSkills");

            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Isactive).HasColumnName("ISACTIVE");
            entity.Property(e => e.Rate).HasMaxLength(100);
            entity.Property(e => e.Skillsid)
                .ValueGeneratedOnAdd()
                .HasColumnName("SKILLSID");
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<AllTask>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("AllTasks");

            entity.Property(e => e.Conditions)
                .HasMaxLength(100)
                .HasColumnName("conditions");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.DeadLine).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.DurationHours).HasColumnName("Duration_HOURS");
            entity.Property(e => e.Level).HasMaxLength(100);
            entity.Property(e => e.Requirements).HasMaxLength(100);
            entity.Property(e => e.Taskid)
                .ValueGeneratedOnAdd()
                .HasColumnName("TASKID");
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<Answer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ID");

            entity.ToTable("ANSWERS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Iscorrect).HasColumnName("ISCORRECT");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("TITLE");

            entity.HasOne(d => d.Question).WithMany(p => p.Answers)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("QUESTION_Answers_REF");
        });

        modelBuilder.Entity<EductionHistory>(entity =>
        {
            entity.HasKey(e => e.EductionHistoryId).HasName("PK__Eduction__B6277E30970BFDE4");

            entity.ToTable("Eduction_History");

            entity.Property(e => e.EductionHistoryId).HasColumnName("Eduction_HistoryId");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("End_Date");
            entity.Property(e => e.NationalityId).HasMaxLength(10);
            entity.Property(e => e.OrginzationName)
                .HasMaxLength(30)
                .HasColumnName("Orginzation_Name");
            entity.Property(e => e.Specification).HasMaxLength(30);
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("Start_Date");
            entity.Property(e => e.Title).HasMaxLength(50);
            entity.Property(e => e.Userid).HasColumnName("USERID");

            entity.HasOne(d => d.User).WithMany(p => p.EductionHistories)
                .HasForeignKey(d => new { d.Userid, d.NationalityId })
                .HasConstraintName("USER_EDUCATIONS");
        });

        modelBuilder.Entity<Exam>(entity =>
        {
            entity.HasKey(e => e.Examid).HasName("PK__EXAM__8D5AA6D0CE426F93");

            entity.ToTable("EXAM");

            entity.Property(e => e.Examid).HasColumnName("EXAMID");
            entity.Property(e => e.Actualmark).HasColumnName("ACTUALMARK");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Level).HasMaxLength(100);
            entity.Property(e => e.NationalityId).HasMaxLength(10);
            entity.Property(e => e.Notes).HasColumnName("NOTES");
            entity.Property(e => e.Submittime)
                .HasColumnType("datetime")
                .HasColumnName("SUBMITTIME");
            entity.Property(e => e.Title).HasMaxLength(50);
            entity.Property(e => e.Userid).HasColumnName("USERID");

            entity.HasOne(d => d.User).WithMany(p => p.Exams)
                .HasForeignKey(d => new { d.Userid, d.NationalityId })
                .HasConstraintName("USER_EXAMS");
        });

        modelBuilder.Entity<Examquestion>(entity =>
        {
            entity.HasKey(e => e.Examquestionid).HasName("PK__EXAMQUES__59E9EC5D08F092C0");

            entity.ToTable("EXAMQUESTION");

            entity.Property(e => e.Examquestionid).HasColumnName("EXAMQUESTIONId");
            entity.Property(e => e.Examid).HasColumnName("EXAMID");
            entity.Property(e => e.Questionid).HasColumnName("QUESTIONID");

            entity.HasOne(d => d.Exam).WithMany(p => p.Examquestions)
                .HasForeignKey(d => d.Examid)
                .HasConstraintName("EXAMQUESTION_EXAM_REF");

            entity.HasOne(d => d.Question).WithMany(p => p.Examquestions)
                .HasForeignKey(d => d.Questionid)
                .HasConstraintName("EXAMQUESTION_QUESTION_REF");
        });

        modelBuilder.Entity<Expierince>(entity =>
        {
            entity.HasKey(e => e.ExpierincesId).HasName("PK__Expierin__D34A372EE1947BE7");

            entity.Property(e => e.ExpierincesId).HasColumnName("ExpierincesID");
            entity.Property(e => e.CompanyName).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Enddate).HasColumnType("datetime");
            entity.Property(e => e.Isactive).HasColumnName("ISActive");
            entity.Property(e => e.NationalityId).HasMaxLength(10);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(100);
            entity.Property(e => e.Userid).HasColumnName("USERID");

            entity.HasOne(d => d.User).WithMany(p => p.Expierinces)
                .HasForeignKey(d => new { d.Userid, d.NationalityId })
                .HasConstraintName("USER_Expierinces");
        });

        modelBuilder.Entity<Getalltask>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GETALLTASKS");

            entity.Property(e => e.Avg).HasColumnName("AVG");
            entity.Property(e => e.DeadLine).HasColumnType("datetime");
            entity.Property(e => e.DurationHours).HasColumnName("Duration_HOURS");
            entity.Property(e => e.FullName).HasMaxLength(60);
            entity.Property(e => e.Mark).HasColumnName("MARK");
            entity.Property(e => e.Students).HasColumnName("STUDENTS");
            entity.Property(e => e.Taskid).HasColumnName("TASKID");
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<Getalltass>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GETALLTASs");

            entity.Property(e => e.Avg).HasColumnName("AVG");
            entity.Property(e => e.DeadLine).HasColumnType("datetime");
            entity.Property(e => e.DurationHours).HasColumnName("Duration_HOURS");
            entity.Property(e => e.FullName).HasMaxLength(60);
            entity.Property(e => e.Mark).HasColumnName("MARK");
            entity.Property(e => e.Students).HasColumnName("STUDENTS");
            entity.Property(e => e.Taskid).HasColumnName("TASKID");
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<Joptitle>(entity =>
        {
            entity.HasKey(e => e.Joptitleid).HasName("PK__JOPTITLE__198182706D66FDC7");

            entity.ToTable("JOPTITLE");

            entity.Property(e => e.Joptitleid).HasColumnName("JOPTITLEID");
            entity.Property(e => e.Conditions)
                .HasMaxLength(100)
                .HasColumnName("conditions");
            entity.Property(e => e.Desc)
                .HasMaxLength(100)
                .HasColumnName("DESC");
            entity.Property(e => e.ExpirencesTime).HasColumnName("Expirences_Time");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Requirements).HasMaxLength(30);
            entity.Property(e => e.Tasks).HasMaxLength(100);
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("PK__Question__0DC06F8C47385E82");

            entity.ToTable("Question");

            entity.Property(e => e.QuestionId).HasColumnName("QuestionID");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Joptitleid).HasColumnName("JOPTITLEID");
            entity.Property(e => e.QuestionTypeId).HasColumnName("QuestionTypeID");
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.Joptitle).WithMany(p => p.Questions)
                .HasForeignKey(d => d.Joptitleid)
                .HasConstraintName("QUESTION_JOPTITLE_REF");

            entity.HasOne(d => d.QuestionType).WithMany(p => p.Questions)
                .HasForeignKey(d => d.QuestionTypeId)
                .HasConstraintName("QUESTION_TYPE_REF");
        });

        modelBuilder.Entity<QuestionType>(entity =>
        {
            entity.HasKey(e => e.QuestionTypeId).HasName("PK__Question__7EDFF9117EBD4569");

            entity.ToTable("QuestionType");

            entity.Property(e => e.QuestionTypeId).HasColumnName("QuestionTypeID");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.Skillsid).HasName("PK__Skills__EEEAC42FED2B024E");

            entity.Property(e => e.Skillsid).HasColumnName("SKILLSID");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Isactive).HasColumnName("ISACTIVE");
            entity.Property(e => e.Rate).HasMaxLength(100);
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.ToTable("TASK");

            entity.Property(e => e.Taskid).HasColumnName("TASKID");
            entity.Property(e => e.Conditions)
                .HasMaxLength(100)
                .HasColumnName("conditions");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.DeadLine).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.DurationHours).HasColumnName("Duration_HOURS");
            entity.Property(e => e.Level).HasMaxLength(100);
            entity.Property(e => e.Requirements).HasMaxLength(100);
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => new { e.Userid, e.NationalityId }).HasName("NationalityId");

            entity.ToTable("USER");

            entity.HasIndex(e => e.Email, "UNIQUE_EMAIL").IsUnique();

            entity.HasIndex(e => e.Phonenumber, "UNIQUE_PHONE").IsUnique();

            entity.Property(e => e.Userid)
                .ValueGeneratedOnAdd()
                .HasColumnName("USERID");
            entity.Property(e => e.NationalityId).HasMaxLength(10);
            entity.Property(e => e.Adress).HasMaxLength(100);
            entity.Property(e => e.Bio).HasMaxLength(500);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("EMAIL");
            entity.Property(e => e.FullName).HasMaxLength(60);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.Password)
                .HasMaxLength(24)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.PersonalPhoto).HasDefaultValueSql("('https://i.pinimg.com/736x/f5/c2/33/f5c233abe166b186b989293ad18ba07a.jpg')");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(13)
                .HasColumnName("PHONENUMBER");
            entity.Property(e => e.Specification).HasMaxLength(30);
            entity.Property(e => e.UserType)
                .HasMaxLength(10)
                .HasDefaultValueSql("('JOB SEEKER')");
        });

        modelBuilder.Entity<Userskill>(entity =>
        {
            entity.HasKey(e => e.Userskills).HasName("PK__USERSKIL__AA8B47A1D46F4E4E");

            entity.ToTable("USERSKILLS");

            entity.Property(e => e.Userskills).HasColumnName("USERSKILLS");
            entity.Property(e => e.NationalityId).HasMaxLength(10);
            entity.Property(e => e.Skillsid).HasColumnName("SKILLSID");
            entity.Property(e => e.Userid).HasColumnName("USERID");

            entity.HasOne(d => d.Skills).WithMany(p => p.Userskills)
                .HasForeignKey(d => d.Skillsid)
                .HasConstraintName("FK__USERSKILL__SKILL__19DFD96B");

            entity.HasOne(d => d.User).WithMany(p => p.Userskills)
                .HasForeignKey(d => new { d.Userid, d.NationalityId })
                .HasConstraintName("FK__USERSKILLS__18EBB532");
        });

        modelBuilder.Entity<Usertask>(entity =>
        {
            entity.HasKey(e => e.Usertasksid).HasName("PK__USERTASK__15A8C0BCEA329977");

            entity.ToTable("USERTASKS");

            entity.Property(e => e.Usertasksid).HasColumnName("USERTASKSID");
            entity.Property(e => e.Actualmark).HasColumnName("ACTUALMARK");
            entity.Property(e => e.NationalityId).HasMaxLength(10);
            entity.Property(e => e.Notes).HasColumnName("NOTES");
            entity.Property(e => e.Submittime)
                .HasColumnType("datetime")
                .HasColumnName("SUBMITTIME");
            entity.Property(e => e.Taskid).HasColumnName("TASKID");
            entity.Property(e => e.Userid).HasColumnName("USERID");

            entity.HasOne(d => d.Task).WithMany(p => p.Usertasks)
                .HasForeignKey(d => d.Taskid)
                .HasConstraintName("FK__USERTASKS__TASKI__2BFE89A6");

            entity.HasOne(d => d.User).WithMany(p => p.Usertasks)
                .HasForeignKey(d => new { d.Userid, d.NationalityId })
                .HasConstraintName("FK__USERTASKS__2B0A656D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
