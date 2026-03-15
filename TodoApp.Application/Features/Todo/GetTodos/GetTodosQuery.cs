namespace TodoApp.Application.Features.Todo.GetTodos;

public class GetTodosQuery
{    
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
}