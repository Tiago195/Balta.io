using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

public class Program
{
  private const string CONNECTION_STRING = "Server=localhost,1433;Database=blog;User ID=sa;Password=Password12;Trusted_Connection=False; TrustServerCertificate=True";
  static void Main(string[] args)
  {
    System.Console.Clear();

    var connection = new SqlConnection(CONNECTION_STRING);
    connection.Open();
    // ReadUsers(connection);
    ReadUsersWithRoles(connection);
    // ReadRoles(connection);
    // ReadTags(connection);
    // CreateUser(connection);
    // UpdateUser(connection);
    // DeleteUser(connection);
    connection.Close();
  }

  public static void ReadUsers(SqlConnection connection)
  {
    var userRepository = new Repository<User>(connection);

    var items = userRepository.Get();

    foreach (var item in items)
    {
      System.Console.WriteLine(item.Name);
    }
  }
  public static void ReadUsersWithRoles(SqlConnection connection)
  {
    var userRepository = new UserRepository(connection);

    var items = userRepository.GetWithRoles();

    foreach (var item in items)
    {
      System.Console.WriteLine(item.Name);
      foreach (var role in item.Roles)
      {
        System.Console.WriteLine($" - {role.Name}");
      }
    }
  }
  public static void CreateUser(SqlConnection connection)
  {
    var user = new User
    {
      Bio = "Bio",
      Email = "Matheus@email.com",
      Image = "https://",
      Name = "Matheus Calheiro",
      PasswordHash = "HASH",
      Slug = "matheus-calheiro"
    };

    var userRepository = new Repository<User>(connection);
    userRepository.Create(user);

  }
  public static void UpdateUser(SqlConnection connection)
  {
    var user = new User
    {
      Id = 3,
      Bio = "meu nome é andré",
      Email = "andre@email.com",
      Image = "https://",
      Name = "Andre Meireles",
      PasswordHash = "SENHA DE VDD",
      Slug = "andre-meireles"
    };

    var userRepository = new Repository<User>(connection);
    userRepository.Update(user);

  }
  public static void DeleteUser(SqlConnection connection)
  {
    var userRepository = new Repository<User>(connection);
    userRepository.Delete(3);
  }
  public static void ReadRoles(SqlConnection connection)
  {
    var userRepository = new Repository<Role>(connection);

    var items = userRepository.Get();

    foreach (var item in items)
    {
      System.Console.WriteLine(item.Name);
    }
  }
  public static void ReadTags(SqlConnection connection)
  {
    var userRepository = new Repository<Tag>(connection);

    var items = userRepository.Get();

    foreach (var item in items)
    {
      System.Console.WriteLine(item.Name);
    }
  }

}