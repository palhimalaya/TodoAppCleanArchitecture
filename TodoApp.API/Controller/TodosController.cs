using Microsoft.AspNetCore.Mvc;
using TodoApp.Application.Features.Todo.CreateTodo;
using TodoApp.Application.Features.Todo.GetTodos;
using TodoApp.Application.Features.Todo.UpdateTodo;
using TodoApp.Application.Features.Todo.DeleteTodo;

namespace TodoApp.API;

[ApiController]
[Route("api/[controller]")]
public class TodosController : ControllerBase
{
    private readonly CreateTodoHandler _createHandler;
    private readonly GetTodosHandler _getHandler;
    private readonly UpdateTodoHandler _updateHandler;
    private readonly DeleteTodoHandler _deleteHandler;

    public TodosController(CreateTodoHandler createHandler, GetTodosHandler getHandler, UpdateTodoHandler updateHandler, DeleteTodoHandler deleteHandler)
    {
        _createHandler = createHandler;
        _getHandler = getHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTodo(CreateTodoCommand command)
    {
        var id = await _createHandler.Handle(command);
        return Ok(id);
    }

    [HttpGet]
    public async Task<IActionResult> GetTodos()
    {
        var todos = await _getHandler.Handle(new GetTodosQuery());
        return Ok(todos);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTodo(Guid id, UpdateTodoCommand command)
    {
        var updatedTodo = await _updateHandler.Handle(id, command);
        return Ok(updatedTodo);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodo(Guid id)
    {
        await _deleteHandler.Handle(new DeleteTodoCommand { Id = id });
        return Ok();
    }
}