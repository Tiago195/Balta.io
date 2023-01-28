namespace OB.ContentContext;

public class Career : Content
{
  public IList<CareerItem> Items { get; set; }
  // Expression body
  public int TotalCourses => Items.Count;
  public Career()
  {
    Items = new List<CareerItem>();
  }
}
