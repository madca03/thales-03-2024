using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StudentEnrollment.Business.Repository
{
    public partial class StudentEnrollmentContext : DbContext
    {
        public StudentEnrollmentContext()
        {
        }

        public StudentEnrollmentContext(DbContextOptions<StudentEnrollmentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Enrollment> Enrollments { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.HasIndex(e => e.EndDate, "IX_Course_EndDate");

                entity.HasIndex(e => e.Name, "IX_Course_Name");

                entity.HasIndex(e => e.StartDate, "IX_Course_StartDate");

                entity.Property(e => e.ContactPerson).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.LocationAddress).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.ToTable("Enrollment");

                entity.HasIndex(e => e.EnrollmentDate, "IX_Enrollment_EnrollmentDate");

                entity.HasIndex(e => new { e.StudentId, e.CourseId }, "UQ_Enrollment_StudentId_CourseId")
                    .IsUnique();

                entity.Property(e => e.Comments).HasMaxLength(100);

                entity.Property(e => e.Status).HasMaxLength(50);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Phone).HasMaxLength(10);
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subject_Course");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
