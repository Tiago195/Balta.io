namespace OB.ContentContext;

public class Career : Content
{
  public IList<CareerItem> Items { get; set; }
  // Expression body
  public int TotalCourses => Items.Count;
  public Career(string title, string url) : base(title, url)
  {
    Items = new List<CareerItem>();
  }
}
