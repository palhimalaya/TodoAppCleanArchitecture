using TodoApp.Domain.Entities;

namespace TodoApp.Application.Interfaces;

public interface ITodoRepository
{
    Task AddAsync(TodoItem todoItem);
    Task<List<TodoItem>> GetAllAsync();
    Task<TodoItem> UpdateAsync(Guid id, TodoItem todoItem);
    Task DeleteAsync(Guid id);
}