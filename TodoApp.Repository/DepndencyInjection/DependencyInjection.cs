using Microsoft.Extensions.DependencyInjection;
using TodoApp.Application.Interfaces;

namespace TodoApp.Repository.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddRepository(this IServiceCollection services)
    {
        services.AddScoped<ITodoRepository, TodoRepository>();

        return services;
    }
}