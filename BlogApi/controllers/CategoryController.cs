using Microsoft.AspNetCore.Mvc;
using BlogApi.Models;
using BlogApi.Data;
using Microsoft.EntityFrameworkCore;
using BlogApi.ViewModels;
using BlogApi.Extensions;
using BlogApi.ViewModels.Categories;

namespace BlogApi.Controllers;

[ApiController]
public class CategoryController : ControllerBase
{

  [HttpGet("v1/categories")]
  public async Task<ActionResult> GetAsync([FromServices] BlogDataContext context)
  {
    try
    {
      var categories = await context.Categories.ToListAsync();
      return Ok(new ResultViewMode<List<Category>>(categories));
    }
    catch (Exception)
    {
      return StatusCode(500, new ResultViewMode<Category>("Internal server error"));
    }
  }

  [HttpGet("v1/categories/{id:int}")]
  public async Task<ActionResult> GetByIdAsync([FromRoute] int id, [FromServices] BlogDataContext context)
  {
    try
    {
      var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);

      if (category is null) return NotFound(new ResultViewMode<Category>("Categoria não encontrada"));

      return Ok(new ResultViewMode<Category>(category));
    }
    catch (Exception)
    {
      return StatusCode(500, new ResultViewMode<Category>("Internal server error"));
    }
  }

  [HttpPost("v1/categories")]
  public async Task<ActionResult> PostAsync([FromBody] EditorCategoryViewModel model, [FromServices] BlogDataContext context)
  {
    try
    {
      if (!ModelState.IsValid) return BadRequest(new ResultViewMode<Category>(ModelState.GetErrors()));

      var category = new Category { Name = model.Name, Slug = model.Slug };
      await context.Categories.AddAsync(category);
      await context.SaveChangesAsync();

      return Created($"v1/categories/{category.Id}", new ResultViewMode<Category>(category));
    }
    catch (Exception)
    {
      return StatusCode(500, new ResultViewMode<Category>("Internal server error"));
    }
  }

  [HttpPut("v1/categories/{id:int}")]
  public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] EditorCategoryViewModel model, [FromServices] BlogDataContext context)
  {
    try
    {
      var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);

      if (category is null) return NotFound(new ResultViewMode<Category>("Categoria não encontrada."));

      category.Name = model.Name;
      category.Slug = model.Slug;

      context.Categories.Update(category);
      await context.SaveChangesAsync();

      return Ok(new ResultViewMode<Category>(category));
    }
    catch (Exception)
    {
      return StatusCode(500, new ResultViewMode<Category>("Internal server error"));
    }
  }

  [HttpDelete("v1/categories/{id:int}")]
  public async Task<ActionResult> DeleteAsync([FromRoute] int id, [FromServices] BlogDataContext context)
  {
    try
    {
      var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);

      if (category is null) return NotFound(new ResultViewMode<Category>("Categoria não encontrada."));

      context.Categories.Remove(category);
      await context.SaveChangesAsync();

      return Ok(new ResultViewMode<Category>(category));
    }
    catch (Exception)
    {
      return StatusCode(500, new ResultViewMode<Category>("Internal server error"));
    }
  }

}
