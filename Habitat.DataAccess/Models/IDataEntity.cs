using System;

namespace Habitat.DataAccess.Models
{
    public interface IDataEntity
    {
        public Guid Id { get; set; }
    }
}