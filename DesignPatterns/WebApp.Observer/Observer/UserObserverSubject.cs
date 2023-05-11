using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Observer.Models;

namespace WebApp.Observer.Observer
{
    public class UserObserverSubject
    {
        private readonly List<IUserObserver> _userObservers;


        public UserObserverSubject()
        {
            _userObservers = new List<IUserObserver>();
        }

        public void RegisterObserver(IUserObserver userObserver)
        {
            _userObservers.Add(userObserver);
        }

        //public void RemoveObserver(IUserObserver userObserver)
        //{
        //    _userObservers.Remove(userObserver);
        //}

        public void NotifyObserver(AppUser user)
        {
            _userObservers.ForEach(x =>
            {
                x.UserCreated(user);
            });
        }
    }
}
