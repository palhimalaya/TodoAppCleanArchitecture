using Microsoft.Extensions.DependencyInjection;
using TodoApp.Application.Features.Todo.CreateTodo;
using TodoApp.Application.Features.Todo.GetTodos;
using TodoApp.Application.Features.Todo.UpdateTodo;
using TodoApp.Application.Features.Todo.DeleteTodo;

namespace TodoApp.Application.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<CreateTodoHandler>();
        services.AddScoped<GetTodosHandler>();
        services.AddScoped<UpdateTodoHandler>();
        services.AddScoped<DeleteTodoHandler>();

        return services;
    }
}