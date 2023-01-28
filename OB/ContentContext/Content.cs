using OB.SharedContext;

namespace OB.ContentContext;

public class Content : Base
{
  public string Title { get; set; }
  public string Url { get; set; }

  public Content(string title, string url)
  {
    Title = title;
    Url = url;
  }
}