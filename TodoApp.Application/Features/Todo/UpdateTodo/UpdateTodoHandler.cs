

using TodoApp.Application.Interfaces;
using TodoApp.Domain.Entities;

namespace TodoApp.Application.Features.Todo.UpdateTodo;

public class UpdateTodoHandler
{
   private readonly ITodoRepository _todoRepository;

    public UpdateTodoHandler(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<TodoItem> Handle(Guid id, UpdateTodoCommand command)
    {
        var todoItem = new TodoItem
        {
            Id = id,
            Title = command.Title,
            IsCompleted = command.IsCompleted,
        };
        return await _todoRepository.UpdateAsync(id, todoItem);
    }
}