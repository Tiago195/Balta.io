namespace OB.NotificationContext;

public abstract class Notifiable
{
  public List<Notification> Notifications { get; set; }
  public bool IsInvalid => Notifications.Any();

  protected Notifiable()
  {
    Notifications = new List<Notification>();
  }

  public void AddNotification(Notification notification)
  {
    Notifications.Add(notification);
  }

  public void AddNotifications(Notification[] notifications)
  {
    Notifications.AddRange(notifications);
  }

}