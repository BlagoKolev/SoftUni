using System;
using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {

        }

        public StudentSystemContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Course> Courses  { get; set; }
        public DbSet<Homework> HomeworkSubmissions { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }
       
        protected  override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(p => p.StudentId);

                entity.Property(p => p.Name)
                .IsRequired(true)
                .HasMaxLength(100)
                .IsUnicode(true);

                entity.Property(p => p.PhoneNumber)
                .HasMaxLength(10)
                .IsFixedLength(true)
                .IsRequired(false)
                .IsUnicode(false);

                entity.Property(s => s.RegisteredOn)
                .IsRequired(true);

                entity.Property(p => p.Birthday)
                .IsRequired(false);


            });

            modelBuilder.Entity<Homework>(entity =>
            {
                entity.HasKey(h => h.HomeworkId);

                entity.Property(h => h.Content)
                .IsRequired(true)
                .IsUnicode(false);
                // CHECK WHAT MEANS = LINKED TO FILE

                entity.Property(h => h.SubmissionTime)
                .IsRequired(true);

                entity.HasOne(h => h.Student)
               .WithMany(s => s.HomeworkSubmissions)
               .HasForeignKey(h => h.StudentId);

                entity.HasOne(h => h.Course)
                .WithMany(c => c.HomeworkSubmissions)
                .HasForeignKey(h => h.CourseId);
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasKey(r => r.ResourceId);

                entity.Property(r => r.Name)
                .HasMaxLength(50)
                .IsRequired(true)
                .IsUnicode(true);

                entity.Property(r => r.Url)
                .IsRequired(true)
                .IsUnicode(false);

                entity.HasOne(r => r.Course)
                .WithMany(c => c.Resources)
                .HasForeignKey(r => r.CourseId);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(c => c.CourseId);

                entity.Property(c => c.Name)
                .HasMaxLength(80)
                .IsRequired(true)
                .IsUnicode(false);

                entity.Property(c => c.Description)
                .IsRequired(false)
                .IsUnicode(true);

                entity.Property(c => c.StartDate)
                .IsRequired(true);

                entity.Property(c => c.EndDate)
                .IsRequired(true);

                entity.Property(c => c.Price)
                .IsRequired(true);
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(st => new { st.StudentId, st.CourseId });

                entity.HasOne(st => st.Student)
                .WithMany(s => s.CourseEnrollments)
                .HasForeignKey(st => st.StudentId);

                entity.HasOne(st => st.Course)
                .WithMany(c => c.StudentsEnrolled)
                .HasForeignKey(st => st.CourseId);
            });
        }

    }
}
