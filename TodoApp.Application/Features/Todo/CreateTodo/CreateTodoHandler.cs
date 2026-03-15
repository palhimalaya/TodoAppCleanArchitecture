using TodoApp.Application.Interfaces;

namespace TodoApp.Application.Features.Todo.CreateTodo;

public class CreateTodoHandler
{
    private readonly ITodoRepository _todoRepository;

    public CreateTodoHandler(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<Guid> Handle(CreateTodoCommand command)
    {
       var todoItem = new Domain.Entities.TodoItem
       {
            Id = Guid.NewGuid(),
            Title = command.Title,
            IsCompleted = false,
       };
       await _todoRepository.AddAsync(todoItem);

       return todoItem.Id;
    }
}