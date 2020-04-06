using Habitat.DataAccess.Configurations;
using Habitat.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Habitat.DataAccess
{
    public class HabitatContext : DbContext
    {
        public HabitatContext(DbContextOptions<HabitatContext> options) : base(options)
        {
            
        }
        
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new NoteConfiguration());
        }
    }
}