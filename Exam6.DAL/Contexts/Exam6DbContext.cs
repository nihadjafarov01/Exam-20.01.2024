using Exam6.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Exam6.DAL.Contexts
{
    public class Exam6DbContext : IdentityDbContext
    {
        public Exam6DbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Instructor> Instructors { get; set; }
    }
}
