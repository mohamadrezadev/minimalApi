using Microsoft.EntityFrameworkCore;
using MyAPi.Models;

namespace MyAPi.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        public DbSet<Command> Commands =>Set<Command>();
       // public DbSet<Command> Commands { get; set; }
    }
}