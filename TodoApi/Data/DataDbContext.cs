using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Context;

public class DataDbContext : DbContext
{
  public DbSet<Todo> Todos { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");
  }
}