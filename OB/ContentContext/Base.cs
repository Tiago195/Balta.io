using OB.NotificationContext;

namespace OB.ContentContext;

public abstract class Base : Notifiable
{
  public Guid Id { get; set; }

  public Base()
  {
    Id = Guid.NewGuid();
  }
}