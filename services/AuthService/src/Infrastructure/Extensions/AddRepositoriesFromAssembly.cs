using Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure.Extensions
{
    internal static class AddRepositoriesFromAssembly
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            var types = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract);

            foreach (var type in types)
            {
                // Получаем все интерфейсы, которые реализует класс, и берем первый - тот от которого наследуется класс
                var implementedInterface = type.GetInterfaces()
                    .FirstOrDefault(i => i != typeof(IRepository) &&
                                        typeof(IRepository).IsAssignableFrom(i));

                if (implementedInterface != null)
                    services.AddScoped(implementedInterface, type);
            }
            return services;
        }
    }
}