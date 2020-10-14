using Microsoft.EntityFrameworkCore;
using StudentResourceManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentResourceManagement.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<Student> Students { get; set; } 
        public DbSet<Resource> Resources { get; set; }
        public DbSet<StudentResource> StudentResources { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentResource>().HasKey(sc => new { sc.SID, sc.RID });
            modelBuilder.Entity<StudentResource>().HasOne(sc => sc.Student)
                .WithMany(b => b.StudentResources)
                .HasForeignKey(sc => sc.SID);
            modelBuilder.Entity<StudentResource>()
                .HasOne(sc => sc.Resource)
                .WithMany(c => c.StudentResources)
                .HasForeignKey(bc => bc.RID);
        }
    }
}
