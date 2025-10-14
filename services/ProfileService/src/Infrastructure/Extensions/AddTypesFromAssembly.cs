using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure.Extensions
{
    internal static class AddTypesFromAssembly
    {
        /// <summary>
        /// It uses reflection to search for all <see langword="types" /> and their <see langword="interfaces" />.
        /// <see langword="add"/> them with a <see  langword="Scoped"/> lifetime, having a <see  langword="TBase"/> interface, in the inheritance chain.
        /// </summary>
        /// <typeparam name="TBase"></typeparam>
        /// <param name="services"></param>
        /// <param name="assembly"></param>
        /// <returns>An <see cref="IServiceCollection"/> contains an input sequence that satisfies the condition.</returns>
        /// <exception cref="ArgumentNullException">If the assembly has the null value.</exception>
        /// <exception cref="ArgumentException">If the Tbase does not belong to the interface type.</exception>
        public static IServiceCollection AddAssemblyTypes<TBase>(this IServiceCollection services, Assembly assembly)
        {
            ArgumentNullException.ThrowIfNull(assembly);

            if (!typeof(TBase).IsInterface)
                throw new ArgumentException("TBase must be an interface type");

            var types = assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract);

            foreach (var type in types)
            {
                // We get all the interfaces that the class implements, and take the first one - the one from which the class inherits.
                var implementedInterface = type.GetInterfaces()
                    .FirstOrDefault(i => i != typeof(TBase) &&
                                        typeof(TBase).IsAssignableFrom(i));

                if (implementedInterface != null)
                    services.AddScoped(implementedInterface, type);
            }
            return services;
        }
    }
}