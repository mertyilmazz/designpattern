using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApp.Observer.Events;
using WebApp.Observer.Models;

namespace WebApp.Observer.EventHandler
{
    public class CreateDiscountEventHandler : INotificationHandler<UserCreatedEvent>
    {
        private readonly AppIdentityDbContext _context;
        private readonly ILogger<CreateDiscountEventHandler> _logger;
        public CreateDiscountEventHandler(ILogger<CreateDiscountEventHandler> logger, AppIdentityDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
        {
            var discount = new Discount()
            {
                Rate = 10,
                UserId = notification.AppUser.Id
            };
            await _context.Discounts.AddAsync(discount);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"discount created : Id= {discount.Id}");
                 
        }
    }
}
