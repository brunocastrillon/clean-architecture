using System;
using MediatR;

namespace Bookstore.SharedKernel
{
    public class BaseDomainEvent : INotification
    {
        public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
    }
}