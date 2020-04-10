using System.Threading;
using System.Threading.Tasks;
using Habitat.Domain.Interfaces;
using Habitat.Domain.Models;
using Habitat.Domain.Notes;
using Habitat.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Habitat.DataAccess.Interfaces
{
    public interface IHabitatContext
    {
        DbSet<Note> Notes { get; set; }
        DbSet<User> Users { get; set; }

        DbSet<T> DataEntitySet<T>() where T : class, IDataEntity;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
    }
}