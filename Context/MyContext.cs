using CollegeInfoSystem.Models;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;

namespace CollegeInfoSystem.Context
{
    public class MyContext:DbContext
    {
        public DbSet<Teacher> teachers { get; set; }
        public DbSet<Student> students { get; set; }

        public MyContext(DbContextOptions options) : base(options) 
        { 

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>(builder =>
            {
                builder.HasKey(t => t.Tid);
                builder.Property(t=>t.Tname).HasColumnName("TeacherName")
                       .HasMaxLength(50).IsRequired();
               builder.Property(t=>t.Subject).IsRequired();
                
                //Providing Relation  to tables 

                builder
                    .HasMany<Student>(t=>t.students)
                    .WithOne(t=>t.Teacher)
                    .HasForeignKey(t=>t.Tid).IsRequired();


            });

            modelBuilder.Entity<Student>(builder =>
            {
                builder.HasKey(s => s.Id);
                builder.Property(s=>s.Sname).HasColumnName("Student_Name")
                .HasMaxLength(50)
                .IsRequired();
                builder.Property(s => s.Email)
                .HasAnnotation("RegularExpression", @"^[a-zA-Z0-9._%+-]+@gmail\.com$")
                .IsRequired();


            });



        }



    }
}
