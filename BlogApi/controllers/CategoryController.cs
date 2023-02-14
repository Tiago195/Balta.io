using Microsoft.AspNetCore.Mvc;
using BlogApi.Models;
using Blog.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Controllers;

[ApiController]
public class CategoryController : ControllerBase
{

  [HttpGet("v1/categories")]
  public async Task<ActionResult> GetAsync([FromServices] BlogDataContext context)
  {
    var categories = await context.Categories.ToListAsync();
    return Ok(categories);
  }

  [HttpGet("v1/categories/{id:int}")]
  public async Task<ActionResult> GetByIdAsync([FromRoute] int id, [FromServices] BlogDataContext context)
  {
    var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);

    if (category is null) return NotFound();

    return Ok(category);
  }

  [HttpPost("v1/categories")]
  public async Task<ActionResult> PostAsync([FromBody] Category model, [FromServices] BlogDataContext context)
  {
    await context.Categories.AddAsync(model);
    await context.SaveChangesAsync();

    return Created($"v1/categories/{model.Id}", model);
  }

  [HttpPut("v1/categories/{id:int}")]
  public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] Category model, [FromServices] BlogDataContext context)
  {
    var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);

    if (category is null) return NotFound();

    category.Name = model.Name;
    category.Slug = model.Slug;

    context.Categories.Update(category);
    await context.SaveChangesAsync();
    return Ok(category);
  }

  [HttpDelete("v1/categories/{id:int}")]
  public async Task<ActionResult> DeleteAsync([FromRoute] int id, [FromServices] BlogDataContext context)
  {
    var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);

    if (category is null) return NotFound();

    context.Categories.Remove(category);
    await context.SaveChangesAsync();

    return Ok(category);
  }

}
