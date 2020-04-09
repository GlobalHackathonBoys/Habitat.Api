using System.Collections.Generic;
using System.Linq;
using Habitat.Application.Interfaces;

namespace Habitat.Application.Extensions
{
    public static class ModelValidatorExtensions
    {
        public static List<string> ToModelValidationList<T>(this IEnumerable<T> validators) where T : IModelValidator
        {
            return validators
                .SelectMany((update, index) => update.Validate().Select(error => $"{typeof(T).Name}[{index}] {error}"))
                .ToList();
        }
    }
}