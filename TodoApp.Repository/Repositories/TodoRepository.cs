using TodoApp.Application.Interfaces;
using TodoApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace TodoApp.Repository;

public class TodoRepository : ITodoRepository
{
    private readonly AppDbContext _context;

    public TodoRepository(AppDbContext  context)
    {
        _context = context;
    }


    public async Task AddAsync(TodoItem todoItem)
    {
        _context.TodoItems.Add(todoItem);
        await _context.SaveChangesAsync();
    }

    public async Task<List<TodoItem>> GetAllAsync()
    {
        return await _context.TodoItems.ToListAsync();
    }

public async Task<TodoItem> UpdateAsync(Guid id, TodoItem todoItem)
    {
        var existingItem = await _context.TodoItems.FindAsync(id);
        if(existingItem == null)
        {
            throw new KeyNotFoundException("Todo item not found.");
        }

        existingItem.Title = todoItem.Title;
        existingItem.IsCompleted = todoItem.IsCompleted;
        await _context.SaveChangesAsync();
        return existingItem;
    }

public async Task DeleteAsync(Guid id)
    {
        var existingItem = await _context.TodoItems.FindAsync(id);
        if(existingItem == null)
        {
            throw new KeyNotFoundException("Todo item not found.");
        }

        _context.TodoItems.Remove(existingItem);
        await _context.SaveChangesAsync();
    }

}