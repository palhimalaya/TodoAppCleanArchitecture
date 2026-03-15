using TodoApp.Application.Interfaces;
using TodoApp.Domain.Entities;

namespace TodoApp.Application.Features.Todo.GetTodos;

public class GetTodosHandler
{
    private readonly ITodoRepository _todoRepository;

    public GetTodosHandler(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<List<TodoItem>> Handle(GetTodosQuery command)
    {
        return await _todoRepository.GetAllAsync();
    }

}