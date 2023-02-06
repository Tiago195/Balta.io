namespace BaltaDataAccess.Models;

public class CareerItem
{
  public string Title { get; set; }
  public string Description { get; set; }
  public int Order { get; set; }
  public Course Course { get; set; }
}