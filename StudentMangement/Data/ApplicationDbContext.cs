using System;
using Microsoft.EntityFrameworkCore;
using StudentMangement.Models;

namespace StudentMangement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<CourseModel> Courses { get; set; }

    }
}
