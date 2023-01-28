namespace OB.NotificationContext;

public abstract class Notifiable
{
  public List<Notification> Notifications { get; set; }

  public void Add(Notification notification)
  {
    Notifications.Add(notification);
  }

  public void AddRange(Notification[] notifications)
  {
    Notifications.AddRange(notifications);
  }
}