using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers;

[ApiController]
public class HomeController : ControllerBase
{
  [HttpGet("")]
  public ActionResult Get() => Ok();
}