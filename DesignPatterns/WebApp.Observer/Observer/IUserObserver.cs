using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Observer.Models;

namespace WebApp.Observer.Observer
{
    public interface IUserObserver
    {
        void CreateUser(AppUser user);
    }
}
