using System;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;

namespace CourseRegistration
{
	public class StudentRegistrationContext : DbContext
	{
        public StudentRegistrationContext(DbContextOptions<StudentRegistrationContext> options) : base(options)
        {
        }

        public StudentRegistrationContext()
        {
        }

        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();


                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }


        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId});

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseId);

            modelBuilder.Entity<Instructor>()
                .HasOne(ins => ins.Course );

            modelBuilder.Entity<Course>().HasData(new Course { CourseId = 1, CourseName = "Front End Development Basics", CourseNumber = "CS01", Description = "For mastering front end Web Development basics."});

            modelBuilder.Entity<Instructor>().HasData(new Instructor { CourseId = 1, InstructorId = 1, EmailAddress = "harshpatel23@gmail.com", FirstName = "Harsh", LastName = "Patel"});

            modelBuilder.Entity<Student>().HasData(new Student { StudentId = 1, EmailAddress = "devganan34@gmail.com", FirstName = "Dev", LastName = "Ganan", PhoneNumber = "123-344-2222" });
        }
    }
}

