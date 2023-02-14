using TodoApi.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataDbContext>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
