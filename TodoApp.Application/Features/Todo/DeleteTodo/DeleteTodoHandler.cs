using TodoApp.Application.Interfaces;

namespace TodoApp.Application.Features.Todo.DeleteTodo;

public class DeleteTodoHandler
{
     private readonly ITodoRepository _todoRepository;

    public DeleteTodoHandler(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task Handle(DeleteTodoCommand command)
    {
        await _todoRepository.DeleteAsync(command.Id);
    }
}