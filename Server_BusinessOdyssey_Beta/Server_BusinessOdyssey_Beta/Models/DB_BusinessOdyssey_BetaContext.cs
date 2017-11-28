using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Server_BusinessOdyssey_Beta.Models
{
    public partial class DB_BusinessOdyssey_BetaContext : DbContext
    {
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Judge> Judge { get; set; }
        public virtual DbSet<JudgesGroup> JudgesGroup { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<ScheduleMaster> ScheduleMaster { get; set; }
        public virtual DbSet<ScoreSheet> ScoreSheet { get; set; }
        public virtual DbSet<ScoreSheetReg> ScoreSheetReg { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentGroup> StudentGroup { get; set; }
        public virtual DbSet<Track> Track { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-I0SDNNG;Database=DB_BusinessOdyssey_Beta;Trusted_Connection=True;");
        }

        public DB_BusinessOdyssey_BetaContext(DbContextOptions<DB_BusinessOdyssey_BetaContext> options)
    : base(options)
{ }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.EventId)
                    .HasColumnName("event_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.EventDate)
                    .HasColumnName("event_Date")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Judge>(entity =>
            {
                entity.Property(e => e.JudgeId).HasColumnName("judge_ID");

                entity.Property(e => e.JGroupName)
                    .IsRequired()
                    .HasColumnName("jGroup_Name")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.JudgeName)
                    .IsRequired()
                    .HasColumnName("judge_Name")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.JGroupNameNavigation)
                    .WithMany(p => p.Judge)
                    .HasForeignKey(d => d.JGroupName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Judge__jGroup_Na__4BAC3F29");
            });

            modelBuilder.Entity<JudgesGroup>(entity =>
            {
                entity.HasKey(e => e.JGroupName);

                entity.Property(e => e.JGroupName)
                    .HasColumnName("jGroup_Name")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.JGroupKey)
                    .HasColumnName("jGroup_Key")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.QuestionId)
                    .HasColumnName("question_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.QuestionPoints).HasColumnName("question_Points");

                entity.Property(e => e.QuestionText)
                    .IsRequired()
                    .HasColumnName("question_Text")
                    .IsUnicode(false);

                entity.Property(e => e.QuestionWeight).HasColumnName("question_Weight");

                entity.Property(e => e.ScoreSheetId).HasColumnName("scoreSheet_ID");

                entity.HasOne(d => d.ScoreSheet)
                    .WithMany(p => p.Question)
                    .HasForeignKey(d => d.ScoreSheetId)
                    .HasConstraintName("FK__Question__scoreS__45F365D3");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.Property(e => e.ScheduleId).HasColumnName("schedule_ID");

                entity.Property(e => e.ScheduleHour).HasColumnName("schedule_hour");
            });

            modelBuilder.Entity<ScheduleMaster>(entity =>
            {
                entity.Property(e => e.ScheduleMasterId).HasColumnName("scheduleMaster_ID");

                entity.Property(e => e.JGroupName)
                    .IsRequired()
                    .HasColumnName("jGroup_Name")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SGroupName)
                    .IsRequired()
                    .HasColumnName("sGroup_Name")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ScheduleId).HasColumnName("schedule_ID");

                entity.HasOne(d => d.JGroupNameNavigation)
                    .WithMany(p => p.ScheduleMaster)
                    .HasForeignKey(d => d.JGroupName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ScheduleM__jGrou__5070F446");

                entity.HasOne(d => d.SGroupNameNavigation)
                    .WithMany(p => p.ScheduleMaster)
                    .HasForeignKey(d => d.SGroupName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ScheduleM__sGrou__5165187F");

                entity.HasOne(d => d.Schedule)
                    .WithMany(p => p.ScheduleMaster)
                    .HasForeignKey(d => d.ScheduleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ScheduleM__sched__52593CB8");
            });

            modelBuilder.Entity<ScoreSheet>(entity =>
            {
                entity.Property(e => e.ScoreSheetId)
                    .HasColumnName("scoreSheet_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ScoreSheetCategory)
                    .HasColumnName("scoreSheet_Category")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TrackId).HasColumnName("track_ID");

                entity.HasOne(d => d.Track)
                    .WithMany(p => p.ScoreSheet)
                    .HasForeignKey(d => d.TrackId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ScoreShee__track__4316F928");
            });

            modelBuilder.Entity<ScoreSheetReg>(entity =>
            {
                entity.ToTable("ScoreSheet_Reg");

                entity.Property(e => e.ScoreSheetRegId).HasColumnName("ScoreSheetReg_ID");

                entity.Property(e => e.JGroupName)
                    .HasColumnName("jGroup_Name")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Points).HasColumnName("points");

                entity.Property(e => e.SGroupName)
                    .IsRequired()
                    .HasColumnName("sGroup_Name")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.TrackId).HasColumnName("track_ID");

                entity.HasOne(d => d.JGroupNameNavigation)
                    .WithMany(p => p.ScoreSheetReg)
                    .HasForeignKey(d => d.JGroupName)
                    .HasConstraintName("FK__ScoreShee__jGrou__403A8C7D");

                entity.HasOne(d => d.SGroupNameNavigation)
                    .WithMany(p => p.ScoreSheetReg)
                    .HasForeignKey(d => d.SGroupName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ScoreShee__sGrou__3F466844");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.StudentId).HasColumnName("student_ID");

                entity.Property(e => e.SGroupName)
                    .IsRequired()
                    .HasColumnName("sGroup_Name")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.StudentName)
                    .IsRequired()
                    .HasColumnName("student_Name")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.StudentSchool)
                    .IsRequired()
                    .HasColumnName("student_School")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.SGroupNameNavigation)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.SGroupName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Student__sGroup___48CFD27E");
            });

            modelBuilder.Entity<StudentGroup>(entity =>
            {
                entity.HasKey(e => e.SGroupName);

                entity.Property(e => e.SGroupName)
                    .HasColumnName("sGroup_Name")
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.TrackId).HasColumnName("track_ID");
            });

            modelBuilder.Entity<Track>(entity =>
            {
                entity.Property(e => e.TrackId)
                    .HasColumnName("track_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.TrackName)
                    .IsRequired()
                    .HasColumnName("track_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
