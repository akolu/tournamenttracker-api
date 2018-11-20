using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using TournamentWebApp.Models;

namespace TournamentWebApp.DataAccess
{
    public class DataContext : DbContext
    {
        public DbSet<Tournament> Tournaments { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;Database=TournamentTracker;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<Tournament>()
        //        .Property(p => p.Name)
        //        .IsRequired();
        //}
    }
}
