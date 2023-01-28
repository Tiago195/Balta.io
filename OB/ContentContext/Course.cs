using OB.ContentContext.Enums;

namespace OB.ContentContext;

public class Course : Content
{
  public Course()
  {
    Modules = new List<Module>();
  }

  public int Tag { get; set; }
  public IList<Module> Modules { get; set; }
  public EContentLevel Level { get; set; }
}
