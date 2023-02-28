namespace BlogApi;

public static class Configuration
{
  public static string JwtKey { get; set; } = "SenhaSuperSecreta";
  public static SmtpConfiguration Smtp = new();

  public class SmtpConfiguration
  {
    public string Host { get; set; }
    public int Port { get; set; } = 25;
    public string Username { get; set; }
    public string Password { get; set; }
  }
}