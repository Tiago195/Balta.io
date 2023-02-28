using BlogApi.Data;
using BlogApi.ViewModels;
using BlogApi.ViewModels.Posts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Controllers;

[ApiController]
public class PostController : ControllerBase
{
  private readonly BlogDataContext _context;
  public PostController(BlogDataContext context) => _context = context;

  [HttpGet("v1/posts")]
  public async Task<ActionResult> GetPosts([FromQuery] int page = 0, [FromQuery] int pageSize = 25)
  {
    var posts = await _context.Posts
      .AsNoTracking()
      .Include(x => x.Category)
      .Include(x => x.Author)
      .Select(x => new PostViewModel
      {
        Id = x.Id,
        Author = $"{x.Author.Name} {x.Author.Email}",
        Category = x.Category.Name,
        LastUpdateDate = x.LastUpdateDate,
        Title = x.Title,
        Slug = x.Slug
      })
      .Skip(page * pageSize)
      .Take(pageSize)
      .ToListAsync();

    return Ok(posts);

  }
}
