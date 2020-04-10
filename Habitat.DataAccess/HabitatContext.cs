using System.Threading;
using System.Threading.Tasks;
using Habitat.Application.Interfaces;
using Habitat.DataAccess.Configurations;
using Habitat.DataAccess.Interfaces;
using Habitat.Domain.Interfaces;
using Habitat.Domain.Models;
using Habitat.Domain.Notes;
using Habitat.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Habitat.DataAccess
{
    public class HabitatContext : DbContext, IHabitatContext
    {
        public HabitatContext(DbContextOptions<HabitatContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new NoteConfiguration());
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<User> Users { get; set; }
        
        public DbSet<T> DataEntitySet<T>() where T : class, IDataEntity
        {
            return base.Set<T>();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            return await Database.BeginTransactionAsync(cancellationToken);
        }
    }
}