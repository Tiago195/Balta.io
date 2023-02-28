using System.Text;
using BlogApi;
using BlogApi.Data;
using BlogApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

ConfigureAuthentication(builder);

builder.Services.AddControllers().ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

ConfigureServices(builder);

var app = builder.Build();

LoadConfiguration(app);
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();

app.Run();

void LoadConfiguration(WebApplication web)
{
  Configuration.JwtKey = web.Configuration.GetValue<string>("JwtKey");

  var smtp = new Configuration.SmtpConfiguration();
  web.Configuration.GetSection("Smtp").Bind(smtp);
  Configuration.Smtp = smtp;
}

void ConfigureAuthentication(WebApplicationBuilder builder)
{

  var Key = Encoding.ASCII.GetBytes(Configuration.JwtKey);

  builder.Services.AddAuthentication(options =>
  {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
  })
  .AddJwtBearer(options =>
  {
    options.TokenValidationParameters = new TokenValidationParameters
    {
      ValidateIssuerSigningKey = true,
      IssuerSigningKey = new SymmetricSecurityKey(Key),
      ValidateIssuer = false,
      ValidateAudience = false
    };
  });
}

void ConfigureServices(WebApplicationBuilder builder)
{
  builder.Services.AddDbContext<BlogDataContext>();
  builder.Services.AddTransient<TokenService>();
}
