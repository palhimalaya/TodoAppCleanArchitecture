namespace TodoApp.Application.Features.Todo.UpdateTodo;

public class UpdateTodoCommand
{
    public string Title { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
}