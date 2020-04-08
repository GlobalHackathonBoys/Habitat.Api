using System.Threading;
using System.Threading.Tasks;
using Habitat.Domain.Interfaces;
using Habitat.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Habitat.DataAccess.Interfaces
{
    public interface IHabitatContext
    {
        DbSet<Note> Notes { get; set; }

        DbSet<T> DataEntitySet<T>() where T : class, IDataEntity;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}