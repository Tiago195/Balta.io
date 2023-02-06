namespace BaltaDataAccess.Models;

public class Course
{
  public string Tag { get; set; }
  public string Title { get; set; }
  public string Summary { get; set; }
  public string Url { get; set; }
  public int Level { get; set; }
  public int DurationInMinutes { get; set; }
}