using OB.SharedContext;

namespace OB.Subscription;

public class Student : Base
{
  public string Name { get; set; }
  public string Email { get; set; }
  public User User { get; set; }
}