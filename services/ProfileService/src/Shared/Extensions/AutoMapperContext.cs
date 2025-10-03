using AutoMapper;

namespace Shared.Extensions
{
    internal static class AutoMapperContext
    {
        public static T GetRequiredItem<T>(this ResolutionContext context, string key)
        {
            if (!context.Items.TryGetValue(key, out var value))
            {
                throw new AutoMapperMappingException($"Required item '{key}' not found in mapping context");
            }

            if (value is T typedValue)
                return typedValue;

            throw new AutoMapperMappingException($"Item '{key}' has type {value.GetType().Name} but expected {typeof(T).Name}");
        }
    }
}