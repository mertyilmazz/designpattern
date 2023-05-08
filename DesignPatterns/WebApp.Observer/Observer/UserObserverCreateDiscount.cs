﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using WebApp.Observer.Models;

namespace WebApp.Observer.Observer
{
    public class UserObserverCreateDiscount : IUserObserver
    {
        private readonly IServiceProvider _serviceProvider;

        public UserObserverCreateDiscount(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void CreateUser(AppUser user)
        {
            var logger = _serviceProvider.GetRequiredService<ILogger<UserObserverCreateDiscount>>();
            logger.LogInformation($"user created : Id= {user.Id}");

            var context = _serviceProvider.GetRequiredService<AppIdentityDbContext>();

            var discount = new Discount()
            {
                Rate = 10,
                UserId = user.Id
            };
            context.Discounts.Add(discount);
            context.SaveChanges();
            logger.LogInformation($"discount created : Id= {discount.Id}");
        }
    }
}
