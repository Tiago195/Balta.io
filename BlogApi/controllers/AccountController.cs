using BlogApi.Data;
using BlogApi.Extensions;
using BlogApi.Models;
using BlogApi.Services;
using BlogApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;

namespace BlogApi.Controllers;

[ApiController]
public class AccountController : ControllerBase
{
  private readonly TokenService _tokenService;
  private readonly BlogDataContext _context;

  public AccountController(TokenService tokenService, BlogDataContext context)
  {
    _tokenService = tokenService;
    _context = context;
  }

  [HttpPost("v1/accounts")]
  public async Task<ActionResult> Post([FromBody] RegisterViewModel model)
  {
    if (!ModelState.IsValid) return BadRequest(new ResultViewMode<string>(ModelState.GetErrors()));

    var user = new User
    {
      Name = model.Name,
      Email = model.Email,
      Slug = model.Email.Replace("@", "-").Replace(".", "-")
    };

    var password = PasswordGenerator.Generate(25);

    user.PasswordHash = PasswordHasher.Hash(password);

    try
    {
      await _context.Users.AddAsync(user);
      await _context.SaveChangesAsync();

      return Ok(new ResultViewMode<dynamic>(new { user = user.Email, password }));
    }
    catch (DbUpdateException)
    {
      return StatusCode(400, new ResultViewMode<string>("Este E-mail já existe"));
    }
    catch (Exception)
    {
      return StatusCode(500, new ResultViewMode<string>("Internal Server Error"));
    }
  }


  [HttpPost("v1/accounts/login")]
  public async Task<ActionResult> Login([FromBody] LoginViewModel model)
  {
    if (!ModelState.IsValid) return BadRequest(new ResultViewMode<string>(ModelState.GetErrors()));

    var user = await _context.Users
      .AsNoTracking()
      .Include(x => x.Roles)
      .FirstOrDefaultAsync(x => x.Email == model.Email);

    if (user is null) return StatusCode(401, new ResultViewMode<string>("Usuário ou senha Inválidos"));

    if (!PasswordHasher.Verify(user.PasswordHash, model.Password)) return StatusCode(401, new ResultViewMode<string>("Usuário ou senha Inválidos"));

    try
    {
      var token = _tokenService.GenerateToken(user);
      return Ok(new ResultViewMode<string>(token, null));
    }
    catch (Exception)
    {
      return StatusCode(500, new ResultViewMode<string>("Internal Server Error"));
    }
  }


}
