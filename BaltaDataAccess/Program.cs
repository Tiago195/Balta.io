// See https://aka.ms/new-console-template for more information

using BaltaDataAccess.Models;
using Dapper;
using Microsoft.Data.SqlClient;

public class Program
{
  public static void Main(string[] args)
  {
    System.Console.Clear();
    const string cs = "Server=localhost,1433;Database=balta;User ID=sa;Password=Password12;Trusted_Connection=False; TrustServerCertificate=True";

    var category = new Category
    {
      Id = new Guid("af3407aa-11ae-4621-a2ef-2028b85507c4"),
      Title = "Frontend 2023"
    };
    var insertCategory = @"INSERT INTO
                            [Category]
                          VALUES
                          (
                            @Id,
                            @Title,
                            @Url,
                            @Summary,
                            @Order,
                            @Description,
                            @Featured
                          )";
    var updateCategory = @"UPDATE [Category] SET [Title]=@Title WHERE [Id] = @Id";

    using (var connection = new SqlConnection(cs))
    {
      connection.Open();
      // UpdateCategoryWithDapper(connection, updateCategory, category);
      // ReadCategoryWithDapper(connection);
      OneToMany(connection);
      connection.Close();
    }
  }

  public static void ReadCategoryWithADO(SqlConnection connection)
  {
    using (var command = new SqlCommand())
    {
      command.Connection = connection;
      command.CommandType = System.Data.CommandType.Text;
      command.CommandText = "SELECT [ID], [Title] FROM [Category];";
      var reader = command.ExecuteReader();

      while (reader.Read())
      {
        System.Console.WriteLine($"Id = {reader.GetGuid(0)}, Title = {reader.GetString(1)}");
      }
    }

  }
  public static void ReadCategoryWithDapper(SqlConnection connection)
  {

    var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");
    foreach (var category in categories) System.Console.WriteLine($"Id = {category.Id}, Title = {category.Title}");

  }
  public static void CreateCategoryWithDapper(SqlConnection connection, string sql, Category category)
  {
    connection.Execute(sql, new
    {
      category.Id,
      category.Title,
      category.Url,
      category.Summary,
      category.Order,
      category.Description,
      category.Featured,
    });
  }
  public static void UpdateCategoryWithDapper(SqlConnection connection, string sql, Category category)
  {
    var rows = connection.Execute(sql, new
    {
      category.Id,
      category.Title
    });

    System.Console.WriteLine($"{rows} linhas afetadas");
  }
  public static void OneToOne(SqlConnection connection)
  {
    var sql = @"
    SELECT
      *
    FROM
      [CareerItem]
    JOIN
      [Course]
    ON [CareerItem].[CourseId] = [Course].[id]
    ";
    var career = connection.Query<CareerItem, Course, CareerItem>
    (
      sql,
      (carrerItem, course) =>
      {
        carrerItem.Course = course;
        return carrerItem;
      },
      splitOn: "id"
    );
    foreach (var item in career)
    {
      System.Console.WriteLine($"Titulo do curso {item.Course.Title}");
    }
  }
  public static void OneToMany(SqlConnection connection)
  {
    var sql = @"
      SELECT
        [Career].[id],
        [Career].[Title],
        [CareerItem].[CareerId],
        [CareerItem].[Title]
      FROM
        [Career]
      JOIN
        [CareerItem]
      ON [Career].[Id] = [CareerItem].[CareerId]
    ";
    var careers = new List<Career>();
    connection.Query<Career, CareerItem, Career>
    (
      sql,
      (career, item) =>
      {
        var car = careers.Where(x => x.Id == career.Id).FirstOrDefault();
        if (car == null)
        {
          car = career;
          car.Items.Add(item);
          careers.Add(car);
        }
        else
        {
          car.Items.Add(item);
        }
        return career;
      },
      splitOn: "CareerId"
    );
    foreach (var career in careers)
    {
      System.Console.WriteLine($"- {career.Title}");
      foreach (var item in career.Items)
      {
        System.Console.WriteLine($" - {item.Title}");
      }
    }
  }

}
