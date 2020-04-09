using System.Collections.Generic;

namespace Habitat.Application.Interfaces
{
    public interface IModelValidator
    {
        List<string> Validate();
    }
}