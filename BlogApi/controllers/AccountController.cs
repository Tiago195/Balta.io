using System.Text.RegularExpressions;
using BlogApi.Data;
using BlogApi.Extensions;
using BlogApi.Models;
using BlogApi.Services;
using BlogApi.ViewModels;
using BlogApi.ViewModels.Accounts;
using Microsoft.AspNetCore.Authorization;
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

  [Authorize]
  [HttpPost("v1/accounts/upload-image")]
  public async Task<ActionResult> UploadImage([FromBody] UploadImageViewModel model)
  {
    var fileName = $"{Guid.NewGuid()}.jpg";
    var data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(model.Base64Image, "");
    var bytes = Convert.FromBase64String(data);

    try
    {
      await System.IO.File.WriteAllBytesAsync($"wwwroot/images/{fileName}", bytes);
    }
    catch (Exception)
    {
      return StatusCode(500, new ResultViewMode<string>("Internal server error"));
    }

    var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == User.Identity.Name);

    if (user is null) return BadRequest(new ResultViewMode<string>("Usuário não encontrado"));

    user.Image = $"http://localhost:5091/images/{fileName}";
    _context.Update(user);
    await _context.SaveChangesAsync();

    return Ok(new ResultViewMode<string>("Foto enviada com sucesso", null));
  }

}
