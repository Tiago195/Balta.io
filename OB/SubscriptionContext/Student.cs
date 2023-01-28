using OB.NotificationContext;
using OB.SharedContext;

namespace OB.Subscription;

public class Student : Base
{
  public string Name { get; set; }
  public string Email { get; set; }
  public User User { get; set; }

  public IList<Subscription> Subscriptions { get; set; }
  public bool IsPremiun => Subscriptions.Any(s => !s.IsInactive);

  public Student()
  {
    Subscriptions = new List<Subscription>();
  }

  public void CreateSubscription(Subscription sub)
  {
    if (IsPremiun)
    {
      AddNotification(new Notification("Premiun", "aluno ja contem uma assinatura"));
      return;
    }

    Subscriptions.Add(sub);
  }
}