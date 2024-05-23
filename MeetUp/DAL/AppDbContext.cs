using MeetUp.Models;
using Microsoft.EntityFrameworkCore;

namespace MeetUp.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Speaker> speakers { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

    }
}
