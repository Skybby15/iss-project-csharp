using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_App.Utils
{
    public abstract class Observer
    {
        List<Subscriber> subscribers = new List<Subscriber>();



        public void AddSubscriber(Subscriber subscriber)
        {
            subscribers.Add(subscriber);
        }

        public void RemoveSubscriber(Subscriber subscriber)
        {
            subscribers.Remove(subscriber);
        }

        protected void NotifySubscribers(UpdateEvent notifEvent)
        {
            foreach (var subscriber in subscribers)
            {
                subscriber.GetNotified(notifEvent);
            }
        }
    }
}
