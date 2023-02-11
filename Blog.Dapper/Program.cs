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

    connection.Close();
  }

}