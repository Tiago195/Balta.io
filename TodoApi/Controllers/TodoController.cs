using Microsoft.AspNetCore.Mvc;
using TodoApi.Context;
using TodoApi.Models;

namespace TodoApi.Controllers;

[ApiController]
public class TodoController : ControllerBase
{
  [HttpGet("/")]
  public IActionResult Get([FromServices] DataDbContext context) => Ok(context.Todos.ToList());

  [HttpGet("/{id:int}")]
  public IActionResult Get([FromRoute] int id, [FromServices] DataDbContext context)
  {
    var todo = context.Todos.FirstOrDefault(todo => todo.Id == id);
    if (todo is null) return NotFound("Tarefa não encontrada.");

    return Ok(todo);
  }

  [HttpPost("/")]
  public IActionResult Create([FromBody] Todo todo, [FromServices] DataDbContext context)
  {
    context.Todos.Add(todo);
    context.SaveChanges();

    return Created($"/{todo.Id}", todo);
  }

  [HttpPut("/{id:int}")]
  public IActionResult Update([FromRoute] int id, [FromBody] Todo todo, [FromServices] DataDbContext context)
  {
    var getTodo = context.Todos.FirstOrDefault(todo => todo.Id == id);

    if (getTodo is null) return NotFound("Tarefa não encontrada.");

    getTodo.Title = todo.Title;
    getTodo.Done = todo.Done;

    context.Todos.Update(getTodo);
    context.SaveChanges();

    return Ok(getTodo);
  }

  [HttpDelete("/{id:int}")]
  public IActionResult Delete([FromRoute] int id, [FromServices] DataDbContext context)
  {
    var todo = context.Todos.FirstOrDefault(todo => todo.Id == id);

    if (todo is null) return NotFound();

    context.Todos.Remove(todo);
    context.SaveChanges();

    return NoContent();
  }
}