using OB.NotificationContext;

namespace OB.SharedContext;

public abstract class Base : Notifiable
{
  public Guid Id { get; set; }

  public Base()
  {
    Id = Guid.NewGuid();
  }
}