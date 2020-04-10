using System;
using Habitat.Domain.Interfaces;

namespace Habitat.Domain.Models
{
    public class DataEntity : IDataEntity
    {
        public Guid Id { get; set; }
    }
}