using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Habitat.DataAccess
{
    public class HabitatDesignTimeDbContextFactory : IDesignTimeDbContextFactory<HabitatContext>
    {
        public HabitatContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<HabitatContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=pass;Database=HabitatDb;");

            return new HabitatContext(optionsBuilder.Options);
        }
    }
}