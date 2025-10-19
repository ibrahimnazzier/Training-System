using Microsoft.EntityFrameworkCore;
namespace Day1.Models
{
    public class Context :  DbContext
    {
        public Context() :base() { }

        public Context(DbContextOptions<Context> dbContextOptions) : base(dbContextOptions)
        {
            
        }
        public DbSet<Department> Department { get; set; }

        public DbSet<Course> Course { get; set; }

        public DbSet<Trainee> Trainee { get; set; }

        public DbSet<Instructor> Instructor { get; set; }

        public DbSet<crsResult> CrsResult { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False; initial catalog = Training_System");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<crsResult>()
                .HasKey(cr => new { cr.TraineeID, cr.CourseID });
            modelBuilder.Entity<crsResult>()
                .HasOne(cr => cr.Trainee)
                .WithMany(t => t.CrsResult)
                .HasForeignKey(cr => cr.TraineeID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<crsResult>()
                .HasOne(cr => cr.Course)
                .WithMany(c => c.CrsResult)
                .HasForeignKey(cr => cr.CourseID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Instructor>()
                .HasOne(i => i.Department)
                .WithMany(d => d.Instructors)
                .HasForeignKey(i => i.DepartmentID)
                .OnDelete(DeleteBehavior.NoAction);
           

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Department)
                .WithMany(d => d.Courses)
                .HasForeignKey(c => c.DepartmentID)
                .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);
           
            modelBuilder.Entity<Trainee>()
                .HasOne(T => T.Department)
                .WithMany(d=> d.Trainees)
                .HasForeignKey(T =>  T.DepartmentID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Instructor>()
                .HasOne(I => I.Course)
                .WithMany(c=> c.Instructors)
                .HasForeignKey(I => I.CourseID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Department>()
                .HasData(
                new Department { Id = 1, Name = "CS", Manager = "Ahmed" },
                new Department { Id = 2, Name = "IS", Manager = "Ali" },
                new Department { Id = 3, Name = "IT", Manager = "Amr" }
                );
            modelBuilder.Entity<Course>()
                    .HasData(
                new Course { Id = 1, Name = "C#", degree = 100, minDegree = 50, Hours= 15, DepartmentID = 1 },
                new Course { Id = 2, Name = "JS", degree = 100, minDegree = 50, Hours = 16, DepartmentID = 2}
                );
            modelBuilder.Entity<Trainee>()
                .HasData(
                new Trainee { Id = 1, grade = 78, Name = "Ali", Address = "Assiut", Image = "m.png", DepartmentID = 1 },
                new Trainee { Id = 2, grade =98, Name = "Ahmed", Address = "Assiut", Image = "m.png", DepartmentID = 2 },
                new Trainee { Id = 3, grade = 50, Name = "Amr", Address = "Assiut", Image = "m.png", DepartmentID = 3 }
                );
            modelBuilder.Entity<Instructor>()
                .HasData
                (
                new Instructor { Id = 1, Address = "Assiut", CourseID = 1, DepartmentID = 1, Img = "m.png", Name = "Ahmed", Salary = 8000 },
                new Instructor { Id = 2, Address = "Assiut", CourseID = 2, DepartmentID = 2, Img = "m.png", Name = "Ali", Salary = 10000 },
                new Instructor { Id = 3, Address = "Cairo", CourseID = 1, DepartmentID = 1, Img = "m.png", Name = "Amr", Salary = 20000 },
                new Instructor { Id = 4, Address = "Assiut", CourseID = 2, DepartmentID = 2, Img = "m.png", Name = "Sayed", Salary = 7000 }


                );
        }
    }
}
